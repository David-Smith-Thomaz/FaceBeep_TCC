import { Component, OnInit, Input, ChangeDetectorRef, OnDestroy, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusDoUsuarioService } from '../statusdousuario.service';
import { LocationHistoryService } from '../../../common/services/location.history';
import { ComponentBase } from "../../../common/components/component.base";
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-statusdousuario-create',
    templateUrl: './statusdousuario-create.component.html',
    styleUrls: ['./statusdousuario-create.component.css'],
})
export class StatusDoUsuarioCreateComponent extends ComponentBase implements OnInit, OnDestroy {

    @Input() vm: ViewModel<any>;
    @Input() parentIdValue: any;
    @Input() parentIdField: string;
    @Input() isParent: boolean;
    @Output() saveEnd = new EventEmitter<any>();
    @Output() backEnd = new EventEmitter<any>();

 
    constructor(private statusDoUsuarioService: StatusDoUsuarioService, private route: ActivatedRoute, private router: Router, private ref: ChangeDetectorRef) {
        super();
        this.vm = null;
    }

    ngOnInit() {
        this.vm = this.statusDoUsuarioService.initVM();
        this.vm.actionDescription = "Cadastrar";

        this.statusDoUsuarioService.detectChanges(this.ref);  
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.statusDoUsuarioService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.statusDoUsuarioService.getInfoGrid(infos);
        });
    }

    onSave(model : any) {

            this.statusDoUsuarioService.save(model).subscribe((result) => {
            this.vm.model.statusDoUsuarioId = result.data.statusDoUsuarioId;
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
        this.statusDoUsuarioService.detectChangesStop();
    }
}
