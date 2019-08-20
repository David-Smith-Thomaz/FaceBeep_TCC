import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { FotoDoParticipanteService } from '../fotodoparticipante.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-fotodoparticipante-print',
    templateUrl: './fotodoparticipante-print.component.html',
    styleUrls: ['./fotodoparticipante-print.component.css'],
})
export class FotoDoParticipantePrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private fotoDoParticipanteService: FotoDoParticipanteService, private route: ActivatedRoute) {
        this.vm = this.fotoDoParticipanteService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.fotoDoParticipanteService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }
        
        this.updateCulture();

    }
    
	updateCulture(culture: string = null) {
        this.fotoDoParticipanteService.updateCulture(culture).then((infos: any) => {
					this.vm.infos = infos;
					this.vm.grid = this.fotoDoParticipanteService.getInfoGrid(infos);
        });
        this.fotoDoParticipanteService.updateCultureMain(culture).then((infos: any) => {
					this.vm.generalInfo = infos;
        });
    }
    
    onPrint() {
        window.print();
    }
   


}
