//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TipoDeUsuarioService } from '../tipodeusuario.service';

@Component({
    selector: 'app-tipodeusuario-container-details',
    templateUrl: './tipodeusuario-container-details.component.html',
    styleUrls: ['./tipodeusuario-container-details.component.css'],
})
export class TipoDeUsuarioContainerDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private tipoDeUsuarioService: TipoDeUsuarioService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.tipoDeUsuarioService.initVM();
    }

    ngOnInit() {

       
    }

}
