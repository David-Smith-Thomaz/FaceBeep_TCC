//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { ParticipanteService } from '../participante.service';

@Component({
    selector: 'app-participante-container-edit',
    templateUrl: './participante-container-edit.component.html',
    styleUrls: ['./participante-container-edit.component.css'],
})
export class ParticipanteContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private participanteService: ParticipanteService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.participanteService.initVM();
    }

    ngOnInit() {

       
    }

}
