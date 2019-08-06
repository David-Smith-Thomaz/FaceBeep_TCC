import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { ParticipanteService } from '../participante.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-participante-print',
    templateUrl: './participante-print.component.html',
    styleUrls: ['./participante-print.component.css'],
})
export class ParticipantePrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private participanteService: ParticipanteService, private route: ActivatedRoute) {
        this.vm = this.participanteService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.participanteService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }
        
        this.updateCulture();

    }
    
	updateCulture(culture: string = null) {
        this.participanteService.updateCulture(culture).then((infos: any) => {
					this.vm.infos = infos;
					this.vm.grid = this.participanteService.getInfoGrid(infos);
        });
        this.participanteService.updateCultureMain(culture).then((infos: any) => {
					this.vm.generalInfo = infos;
        });
    }
    
    onPrint() {
        window.print();
    }
   


}
