//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { FotoDoParticipanteService } from '../fotodoparticipante.service';

@Component({
    selector: 'app-fotodoparticipante-container-details',
    templateUrl: './fotodoparticipante-container-details.component.html',
    styleUrls: ['./fotodoparticipante-container-details.component.css'],
})
export class FotoDoParticipanteContainerDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private fotoDoParticipanteService: FotoDoParticipanteService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.fotoDoParticipanteService.initVM();
    }

    ngOnInit() {

       
    }

}
