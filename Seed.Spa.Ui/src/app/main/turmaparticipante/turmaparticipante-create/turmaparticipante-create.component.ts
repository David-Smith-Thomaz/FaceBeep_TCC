import { Component, OnInit, Input, ChangeDetectorRef, OnDestroy, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TurmaParticipanteService } from '../turmaparticipante.service';
import { LocationHistoryService } from '../../../common/services/location.history';
import { ComponentBase } from "../../../common/components/component.base";
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-turmaparticipante-create',
    templateUrl: './turmaparticipante-create.component.html',
    styleUrls: ['./turmaparticipante-create.component.css'],
})
export class TurmaParticipanteCreateComponent extends ComponentBase implements OnInit, OnDestroy {

    @Input() vm: ViewModel<any>;
    @Input() parentIdValue: any;
    @Input() parentIdField: string;
    @Input() isParent: boolean;
    @Output() saveEnd = new EventEmitter<any>();
    @Output() backEnd = new EventEmitter<any>();

 
    constructor(private turmaParticipanteService: TurmaParticipanteService, private route: ActivatedRoute, private router: Router, private ref: ChangeDetectorRef) {
        super();
        this.vm = null;
    }

    ngOnInit() {
        this.vm = this.turmaParticipanteService.initVM();
        this.vm.actionDescription = "Cadastrar";

        this.turmaParticipanteService.detectChanges(this.ref);  
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.turmaParticipanteService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.turmaParticipanteService.getInfoGrid(infos);
        });
    }

    onSave(model : any) {

            this.turmaParticipanteService.save(model).subscribe((result) => {
            this.vm.model.turmaParticipanteId = result.data.turmaParticipanteId;
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
        this.turmaParticipanteService.detectChangesStop();
    }
}
