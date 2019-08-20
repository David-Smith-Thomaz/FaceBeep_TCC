//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { FotoDoParticipanteService } from '../fotodoparticipante.service';

@Component({
    selector: 'app-fotodoparticipante-container-create',
    templateUrl: './fotodoparticipante-container-create.component.html',
    styleUrls: ['./fotodoparticipante-container-create.component.css'],
})
export class FotoDoParticipanteContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private fotoDoParticipanteService: FotoDoParticipanteService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.fotoDoParticipanteService.initVM();
    }

    ngOnInit() {

       
    }

}
