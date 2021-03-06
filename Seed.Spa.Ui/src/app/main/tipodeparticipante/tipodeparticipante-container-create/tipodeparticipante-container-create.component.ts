﻿//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TipoDeParticipanteService } from '../tipodeparticipante.service';

@Component({
    selector: 'app-tipodeparticipante-container-create',
    templateUrl: './tipodeparticipante-container-create.component.html',
    styleUrls: ['./tipodeparticipante-container-create.component.css'],
})
export class TipoDeParticipanteContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private tipoDeParticipanteService: TipoDeParticipanteService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.tipoDeParticipanteService.initVM();
    }

    ngOnInit() {

       
    }

}
