//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { UsuarioService } from '../usuario.service';

@Component({
    selector: 'app-usuario-container-filter',
    templateUrl: './usuario-container-filter.component.html',
    styleUrls: ['./usuario-container-filter.component.css'],
})
export class UsuarioContainerFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private usuarioService: UsuarioService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.usuarioService.initVM();
    }

    ngOnInit() {

       
    }

}
