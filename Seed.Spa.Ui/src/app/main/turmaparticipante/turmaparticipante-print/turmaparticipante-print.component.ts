import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { TurmaParticipanteService } from '../turmaparticipante.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-turmaparticipante-print',
    templateUrl: './turmaparticipante-print.component.html',
    styleUrls: ['./turmaparticipante-print.component.css'],
})
export class TurmaParticipantePrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private turmaParticipanteService: TurmaParticipanteService, private route: ActivatedRoute) {
        this.vm = this.turmaParticipanteService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.turmaParticipanteService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }
        
        this.updateCulture();

    }
    
	updateCulture(culture: string = null) {
        this.turmaParticipanteService.updateCulture(culture).then((infos: any) => {
					this.vm.infos = infos;
					this.vm.grid = this.turmaParticipanteService.getInfoGrid(infos);
        });
        this.turmaParticipanteService.updateCultureMain(culture).then((infos: any) => {
					this.vm.generalInfo = infos;
        });
    }
    
    onPrint() {
        window.print();
    }
   


}
