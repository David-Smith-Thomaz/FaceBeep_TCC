import { Component, OnInit, Input, ChangeDetectorRef, OnDestroy, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { FotoDoParticipanteService } from '../fotodoparticipante.service';
import { LocationHistoryService } from '../../../common/services/location.history';
import { ComponentBase } from "../../../common/components/component.base";
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-fotodoparticipante-create',
    templateUrl: './fotodoparticipante-create.component.html',
    styleUrls: ['./fotodoparticipante-create.component.css'],
})
export class FotoDoParticipanteCreateComponent extends ComponentBase implements OnInit, OnDestroy {

    @Input() vm: ViewModel<any>;
    @Input() parentIdValue: any;
    @Input() parentIdField: string;
    @Input() isParent: boolean;
    @Output() saveEnd = new EventEmitter<any>();
    @Output() backEnd = new EventEmitter<any>();

 
    constructor(private fotoDoParticipanteService: FotoDoParticipanteService, private route: ActivatedRoute, private router: Router, private ref: ChangeDetectorRef) {
        super();
        this.vm = null;
    }

    ngOnInit() {
        this.vm = this.fotoDoParticipanteService.initVM();
        this.vm.actionDescription = "Cadastrar";

        this.fotoDoParticipanteService.detectChanges(this.ref);  
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.fotoDoParticipanteService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.fotoDoParticipanteService.getInfoGrid(infos);
        });
    }

    onSave(model : any) {

            this.fotoDoParticipanteService.save(model).subscribe((result) => {
            this.vm.model.fotoDoParticipateId = result.data.fotoDoParticipateId;
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
        this.fotoDoParticipanteService.detectChangesStop();
    }
}
