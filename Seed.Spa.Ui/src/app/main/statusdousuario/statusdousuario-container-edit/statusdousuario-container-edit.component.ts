//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusDoUsuarioService } from '../statusdousuario.service';

@Component({
    selector: 'app-statusdousuario-container-edit',
    templateUrl: './statusdousuario-container-edit.component.html',
    styleUrls: ['./statusdousuario-container-edit.component.css'],
})
export class StatusDoUsuarioContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusDoUsuarioService: StatusDoUsuarioService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusDoUsuarioService.initVM();
    }

    ngOnInit() {

       
    }

}
