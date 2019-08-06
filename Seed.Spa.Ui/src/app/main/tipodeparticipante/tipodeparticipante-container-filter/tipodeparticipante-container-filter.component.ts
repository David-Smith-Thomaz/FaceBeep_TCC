//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TipoDeParticipanteService } from '../tipodeparticipante.service';

@Component({
    selector: 'app-tipodeparticipante-container-filter',
    templateUrl: './tipodeparticipante-container-filter.component.html',
    styleUrls: ['./tipodeparticipante-container-filter.component.css'],
})
export class TipoDeParticipanteContainerFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private tipoDeParticipanteService: TipoDeParticipanteService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.tipoDeParticipanteService.initVM();
    }

    ngOnInit() {

       
    }

}
