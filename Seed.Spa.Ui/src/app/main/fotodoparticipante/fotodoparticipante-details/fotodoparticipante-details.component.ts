import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { FotoDoParticipanteService } from '../fotodoparticipante.service';

@Component({
    selector: 'app-fotodoparticipante-details',
    templateUrl: './fotodoparticipante-details.component.html',
    styleUrls: ['./fotodoparticipante-details.component.css'],
})
export class FotoDoParticipanteDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private fotoDoParticipanteService: FotoDoParticipanteService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.fotoDoParticipanteService.initVM();

    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id) {
            this.fotoDoParticipanteService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            })
        };
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.fotoDoParticipanteService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.fotoDoParticipanteService.getInfoGrid(infos);
        });
    }

    
}
