import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { TipoDeParticipanteService } from '../tipodeparticipante.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-tipodeparticipante-print',
    templateUrl: './tipodeparticipante-print.component.html',
    styleUrls: ['./tipodeparticipante-print.component.css'],
})
export class TipoDeParticipantePrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private tipoDeParticipanteService: TipoDeParticipanteService, private route: ActivatedRoute) {
        this.vm = this.tipoDeParticipanteService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.tipoDeParticipanteService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }
        
        this.updateCulture();

    }
    
	updateCulture(culture: string = null) {
        this.tipoDeParticipanteService.updateCulture(culture).then((infos: any) => {
					this.vm.infos = infos;
					this.vm.grid = this.tipoDeParticipanteService.getInfoGrid(infos);
        });
        this.tipoDeParticipanteService.updateCultureMain(culture).then((infos: any) => {
					this.vm.generalInfo = infos;
        });
    }
    
    onPrint() {
        window.print();
    }
   


}
