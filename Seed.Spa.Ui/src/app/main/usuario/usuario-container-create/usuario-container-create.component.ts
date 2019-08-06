//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { UsuarioService } from '../usuario.service';

@Component({
    selector: 'app-usuario-container-create',
    templateUrl: './usuario-container-create.component.html',
    styleUrls: ['./usuario-container-create.component.css'],
})
export class UsuarioContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private usuarioService: UsuarioService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.usuarioService.initVM();
    }

    ngOnInit() {

       
    }

}
