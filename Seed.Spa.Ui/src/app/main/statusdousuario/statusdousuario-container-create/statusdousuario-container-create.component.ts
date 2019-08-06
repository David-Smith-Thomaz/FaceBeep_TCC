//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusDoUsuarioService } from '../statusdousuario.service';

@Component({
    selector: 'app-statusdousuario-container-create',
    templateUrl: './statusdousuario-container-create.component.html',
    styleUrls: ['./statusdousuario-container-create.component.css'],
})
export class StatusDoUsuarioContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private statusDoUsuarioService: StatusDoUsuarioService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusDoUsuarioService.initVM();
    }

    ngOnInit() {

       
    }

}
