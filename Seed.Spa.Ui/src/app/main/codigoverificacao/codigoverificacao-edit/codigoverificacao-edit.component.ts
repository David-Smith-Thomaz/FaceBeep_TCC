﻿import { Component, OnInit, Input, ChangeDetectorRef, OnDestroy, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { CodigoVerificacaoService } from '../codigoverificacao.service';
import { LocationHistoryService } from '../../../common/services/location.history';
import { ComponentBase } from '../../../common/components/component.base';
import { GlobalService, NotificationParameters} from '../../../global.service';


@Component({
    selector: 'app-codigoverificacao-edit',
    templateUrl: './codigoverificacao-edit.component.html',
    styleUrls: ['./codigoverificacao-edit.component.css'],
})
export class CodigoVerificacaoEditComponent extends ComponentBase implements OnInit, OnDestroy {

    @Input() vm: ViewModel<any>;
    @Input() parentIdValue: any;
    @Input() parentIdField: string;
    @Input() isParent: boolean;
    @Output() saveEnd = new EventEmitter<any>();
    @Output() backEnd = new EventEmitter<any>();

    id: number;
    private sub: any;

    constructor(private codigoVerificacaoService: CodigoVerificacaoService, private route: ActivatedRoute, private router: Router, private ref: ChangeDetectorRef) {
        super();
        this.vm = null;
    }

    ngOnInit() {

        this.vm = this.codigoVerificacaoService.initVM();
        this.vm.actionDescription = "Edição";

        this.codigoVerificacaoService.detectChanges(this.ref);

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        this.codigoVerificacaoService.get({ id: this.id }).subscribe((data) => {
            this.vm.model = data.data;
            this.showContainerEdit();
        })

        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.codigoVerificacaoService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.codigoVerificacaoService.getInfoGrid(infos);
        });
    }

    onSave(model : any) {
        this.codigoVerificacaoService.save(model).subscribe((result) => {
        this.saveEnd.emit();
        if (!this.vm.manterTelaAberta)
                this.router.navigate([LocationHistoryService.getLastNavigation(this.vm.key)]);
        });
    }

    onBack(e: any) {
        e.preventDefault();
        this.backEnd.emit();
    }

    ngOnDestroy() {
        this.codigoVerificacaoService.detectChangesStop();
    }
}
