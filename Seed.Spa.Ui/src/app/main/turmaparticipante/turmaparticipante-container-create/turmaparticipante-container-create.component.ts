//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TurmaParticipanteService } from '../turmaparticipante.service';

@Component({
    selector: 'app-turmaparticipante-container-create',
    templateUrl: './turmaparticipante-container-create.component.html',
    styleUrls: ['./turmaparticipante-container-create.component.css'],
})
export class TurmaParticipanteContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private turmaParticipanteService: TurmaParticipanteService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.turmaParticipanteService.initVM();
    }

    ngOnInit() {

       
    }

}
