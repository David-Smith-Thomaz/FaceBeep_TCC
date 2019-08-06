//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TurmaParticipanteService } from '../turmaparticipante.service';

@Component({
    selector: 'app-turmaparticipante-container-edit',
    templateUrl: './turmaparticipante-container-edit.component.html',
    styleUrls: ['./turmaparticipante-container-edit.component.css'],
})
export class TurmaParticipanteContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private turmaParticipanteService: TurmaParticipanteService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.turmaParticipanteService.initVM();
    }

    ngOnInit() {

       
    }

}
