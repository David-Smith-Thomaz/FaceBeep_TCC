//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusDoUsuarioService } from '../statusdousuario.service';

@Component({
    selector: 'app-statusdousuario-container-details',
    templateUrl: './statusdousuario-container-details.component.html',
    styleUrls: ['./statusdousuario-container-details.component.css'],
})
export class StatusDoUsuarioContainerDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusDoUsuarioService: StatusDoUsuarioService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusDoUsuarioService.initVM();
    }

    ngOnInit() {

       
    }

}
