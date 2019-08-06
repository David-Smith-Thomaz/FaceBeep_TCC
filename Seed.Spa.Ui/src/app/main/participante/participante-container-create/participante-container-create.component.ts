//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { ParticipanteService } from '../participante.service';

@Component({
    selector: 'app-participante-container-create',
    templateUrl: './participante-container-create.component.html',
    styleUrls: ['./participante-container-create.component.css'],
})
export class ParticipanteContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private participanteService: ParticipanteService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.participanteService.initVM();
    }

    ngOnInit() {

       
    }

}
