//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TipoDeUsuarioService } from '../tipodeusuario.service';

@Component({
    selector: 'app-tipodeusuario-container-create',
    templateUrl: './tipodeusuario-container-create.component.html',
    styleUrls: ['./tipodeusuario-container-create.component.css'],
})
export class TipoDeUsuarioContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private tipoDeUsuarioService: TipoDeUsuarioService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.tipoDeUsuarioService.initVM();
    }

    ngOnInit() {

       
    }

}
