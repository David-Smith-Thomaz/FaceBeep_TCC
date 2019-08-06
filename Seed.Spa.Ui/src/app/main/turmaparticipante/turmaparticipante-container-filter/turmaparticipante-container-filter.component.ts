//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TurmaParticipanteService } from '../turmaparticipante.service';

@Component({
    selector: 'app-turmaparticipante-container-filter',
    templateUrl: './turmaparticipante-container-filter.component.html',
    styleUrls: ['./turmaparticipante-container-filter.component.css'],
})
export class TurmaParticipanteContainerFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private turmaParticipanteService: TurmaParticipanteService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.turmaParticipanteService.initVM();
    }

    ngOnInit() {

       
    }

}
