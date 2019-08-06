//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { ParticipanteService } from '../participante.service';

@Component({
    selector: 'app-participante-container-filter',
    templateUrl: './participante-container-filter.component.html',
    styleUrls: ['./participante-container-filter.component.css'],
})
export class ParticipanteContainerFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private participanteService: ParticipanteService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.participanteService.initVM();
    }

    ngOnInit() {

       
    }

}
