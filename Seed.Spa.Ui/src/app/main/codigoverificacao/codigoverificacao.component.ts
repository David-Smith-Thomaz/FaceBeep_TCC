import { Component, OnInit, ViewChild, Output, EventEmitter, ChangeDetectorRef, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule, FormGroup, FormControl} from '@angular/forms';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { CodigoVerificacaoService } from './codigoverificacao.service';
import { ViewModel } from '../../common/model/viewmodel';
import { GlobalService, NotificationParameters} from '../../global.service';
import { ComponentBase } from '../../common/components/component.base';
import { LocationHistoryService } from '../../common/services/location.history';

@Component({
    selector: 'app-codigoverificacao',
    templateUrl: './codigoverificacao.component.html',
    styleUrls: ['./codigoverificacao.component.css'],
})
export class CodigoVerificacaoComponent extends ComponentBase implements OnInit, OnDestroy {

    @Input() parentIdValue: any;
    @Input() parentIdField: string;
    @Input() isParent: boolean;

    vm: ViewModel<any>;
	
    operationConfimationYes: any;
    changeCultureEmitter: EventEmitter<string>;

    @ViewChild('filterModal') private filterModal: ModalDirective;
    @ViewChild('saveModal') private saveModal: ModalDirective;
    @ViewChild('editModal') private editModal: ModalDirective;
    @ViewChild('detailsModal') private detailsModal: ModalDirective;
    
    constructor(private codigoVerificacaoService: CodigoVerificacaoService, private router: Router, private ref: ChangeDetectorRef) {

        super();
        this.vm = null;

    }

    ngOnInit() {

        this.vm = this.codigoVerificacaoService.initVM();
        this.configurationForParent();

        if (this.parentIdValue) 
            this.vm.modelFilter[this.parentIdField] = this.parentIdValue;

        this.codigoVerificacaoService.detectChanges(this.ref);
        this.codigoVerificacaoService.OnHide(this.saveModal, this.editModal, () => { this.hideComponents() });

        this.onFilter(this.vm.modelFilter);

        this.updateCulture();

        this.changeCultureEmitter = GlobalService.getChangeCultureEmitter().subscribe((culture : any) => {
            this.updateCulture(culture);
        });

    
        this.vm.isParent = this.isParent;
        this.vm.ParentIdField = this.parentIdField;
    }

    configurationForParent() {
        if (this.isParent) {
            this._showBtnBack = false;
            this._showBtnFilter = false;
            this._showBtnDetails = false;
            this._showBtnPrint = false;
        }
    }

    updateCulture(culture: string = null)
    {
        this.codigoVerificacaoService.updateCulture(culture).then((infos : any) => {
            this.vm.infos = infos;
            this.vm.grid = this.codigoVerificacaoService.getInfoGrid(infos);
        });
        this.codigoVerificacaoService.updateCultureMain(culture).then((infos: any) => {
            this.vm.generalInfo = infos;
        });
    }


    public onFilter(modelFilter: any) {
        modelFilter.queryOptimizerBehavior = "GRID_CodigoVerificacao".toUpperCase();
        this.codigoVerificacaoService.get(modelFilter).subscribe((result) => {
            this.vm.filterResult = result.dataList;
            this.vm.summary = result.summary;
            this.filterModal.hide();
        })
    }

    public onExport() {
        this.codigoVerificacaoService.export(Object.assign(this.vm.modelFilter, { AttributeBehavior: "exportar" })).subscribe((result) => {
            var a = document.createElement("a");
            document.body.appendChild(a);
            (a as HTMLElement).style.visibility = 'hidden';

            var blob = new Blob([result], {
            	type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'
            });

            var downloadUrl = window.URL.createObjectURL(blob);

            a.href = downloadUrl;
            a.download = "CodigoVerificacao.xlsx";
            a.click();
            window.URL.revokeObjectURL(downloadUrl);
        })
    }

    public onCreate() {

        this.showContainerCreate();

        this.vm.model = {};
        if (this.parentIdValue)
            this.vm.model[this.parentIdField] = this.parentIdValue;

        this.navigateStrategy(this.vm, this.saveModal, this.router, "/codigoverificacao/create");
    }

    public onEdit(model: any) {

        this.vm.model = {};
        let newModel : any = model;
        if (model)  {
            newModel = { id: model.codigoVerificacaoId }
        }

        if (!this.vm.navigationModal) {
            this.navigateStrategy(this.vm, this.editModal, this.router, "/codigoverificacao/edit/" + newModel.id);
        }
        else {
            this.codigoVerificacaoService.get(newModel).subscribe((result) => {
				      this.vm.model = result.dataList ? result.dataList[0] : result.data;
				      this.showContainerEdit();
				      this.editModal.show();
            })
        }
    }

    public onSave(model: any) {

        this.codigoVerificacaoService.save(model).subscribe((result) => {

             this.onFilter(this.vm.modelFilter);

            if (!this.vm.manterTelaAberta) {
                this.saveModal.hide();
                this.editModal.hide();
                this.hideContainerCreate();
                this.hideContainerEdit();
            }

        });

    }

    public onDetails(model: any) {
    
        this.vm.details = {};
        let newModel : any = model;
        if (model)
        {
            newModel = { id: model.codigoVerificacaoId }
        }
		
        if (!this.vm.navigationModal) {
            this.navigateStrategy(this.vm, this.editModal, this.router, "/codigoverificacao/details/" + newModel.id);
        }
        else {
            this.codigoVerificacaoService.get(newModel).subscribe((result) => {
				      this.vm.details = result.dataList ? result.dataList[0] : result.data;
				      this.showContainerDetails();
				      this.detailsModal.show();
            })
        }

    }

    public onCancel() {

        this.saveModal.hide();
        this.editModal.hide();
        this.detailsModal.hide();
        this.filterModal.hide();
        this.hideComponents();
    }

    public onShowFilter() {
        this.showContainerFilters();
        this.filterModal.show();
    }

    public onClearFilter() {
        this.vm.modelFilter = {};
        GlobalService.getNotificationEmitter().emit(new NotificationParameters("init", {
            model: {}
        }));
    }

    public onPrint(model: any) {
        this.router.navigate(['/codigoverificacao/print', model.codigoVerificacaoId]);
    }

    public onDeleteConfimation(model: any) {

        var conf = GlobalService.operationExecutedParameters(
            "confirm-modal",
            () => {
                let newModel : any = model;
                if (model)
                {    
                    newModel = { id: model.codigoVerificacaoId }
                }
                this.codigoVerificacaoService.delete(newModel).subscribe((result) => {
                    this.vm.filterResult = this.vm.filterResult.filter(function (model) {
                        return  model.codigoVerificacaoId != result.data.codigoVerificacaoId;
                    });
                    this.vm.summary.total = this.vm.filterResult.length
                });
            }
        );

        GlobalService.getOperationExecutedEmitter().emit(conf);
    }

    public onConfimationYes() {
        this.operationConfimationYes();
    }

    public onPageChanged(pageConfig: any) {

        let modelFilter = this.codigoVerificacaoService.pagingConfig(this.vm.modelFilter, pageConfig);
        this.codigoVerificacaoService.get(modelFilter).subscribe((result) => {
            this.vm.filterResult = result.dataList;
            this.vm.summary = result.summary;
        });
    }

    public onOrderBy(order: any) {

        let modelFilter = this.codigoVerificacaoService.orderByConfig(this.vm.modelFilter, order);
        this.codigoVerificacaoService.get(modelFilter).subscribe((result) => {
            this.vm.filterResult = result.dataList;
            this.vm.summary = result.summary;
        });
    }

    ngOnDestroy() {
        this.changeCultureEmitter.unsubscribe();
        this.codigoVerificacaoService.detectChangesStop();
    }

}
