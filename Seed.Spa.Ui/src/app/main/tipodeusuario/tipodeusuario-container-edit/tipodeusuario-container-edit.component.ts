//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TipoDeUsuarioService } from '../tipodeusuario.service';

@Component({
    selector: 'app-tipodeusuario-container-edit',
    templateUrl: './tipodeusuario-container-edit.component.html',
    styleUrls: ['./tipodeusuario-container-edit.component.css'],
})
export class TipoDeUsuarioContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private tipoDeUsuarioService: TipoDeUsuarioService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.tipoDeUsuarioService.initVM();
    }

    ngOnInit() {

       
    }

}
