//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TipoDeParticipanteService } from '../tipodeparticipante.service';

@Component({
    selector: 'app-tipodeparticipante-container-edit',
    templateUrl: './tipodeparticipante-container-edit.component.html',
    styleUrls: ['./tipodeparticipante-container-edit.component.css'],
})
export class TipoDeParticipanteContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private tipoDeParticipanteService: TipoDeParticipanteService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.tipoDeParticipanteService.initVM();
    }

    ngOnInit() {

       
    }

}
