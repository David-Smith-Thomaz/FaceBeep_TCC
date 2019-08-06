//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TurmaParticipanteService } from '../turmaparticipante.service';

@Component({
    selector: 'app-turmaparticipante-container-details',
    templateUrl: './turmaparticipante-container-details.component.html',
    styleUrls: ['./turmaparticipante-container-details.component.css'],
})
export class TurmaParticipanteContainerDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private turmaParticipanteService: TurmaParticipanteService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.turmaParticipanteService.initVM();
    }

    ngOnInit() {

       
    }

}
