//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { UsuarioService } from '../usuario.service';

@Component({
    selector: 'app-usuario-container-details',
    templateUrl: './usuario-container-details.component.html',
    styleUrls: ['./usuario-container-details.component.css'],
})
export class UsuarioContainerDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private usuarioService: UsuarioService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.usuarioService.initVM();
    }

    ngOnInit() {

       
    }

}
