import { Component, OnInit, Input, ChangeDetectorRef, OnDestroy, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TipoDeUsuarioService } from '../tipodeusuario.service';
import { LocationHistoryService } from '../../../common/services/location.history';
import { ComponentBase } from "../../../common/components/component.base";
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-tipodeusuario-create',
    templateUrl: './tipodeusuario-create.component.html',
    styleUrls: ['./tipodeusuario-create.component.css'],
})
export class TipoDeUsuarioCreateComponent extends ComponentBase implements OnInit, OnDestroy {

    @Input() vm: ViewModel<any>;
    @Input() parentIdValue: any;
    @Input() parentIdField: string;
    @Input() isParent: boolean;
    @Output() saveEnd = new EventEmitter<any>();
    @Output() backEnd = new EventEmitter<any>();

 
    constructor(private tipoDeUsuarioService: TipoDeUsuarioService, private route: ActivatedRoute, private router: Router, private ref: ChangeDetectorRef) {
        super();
        this.vm = null;
    }

    ngOnInit() {
        this.vm = this.tipoDeUsuarioService.initVM();
        this.vm.actionDescription = "Cadastrar";

        this.tipoDeUsuarioService.detectChanges(this.ref);  
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.tipoDeUsuarioService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.tipoDeUsuarioService.getInfoGrid(infos);
        });
    }

    onSave(model : any) {

            this.tipoDeUsuarioService.save(model).subscribe((result) => {
            this.vm.model.tipoDeUsuarioId = result.data.tipoDeUsuarioId;
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
        this.tipoDeUsuarioService.detectChangesStop();
    }
}
