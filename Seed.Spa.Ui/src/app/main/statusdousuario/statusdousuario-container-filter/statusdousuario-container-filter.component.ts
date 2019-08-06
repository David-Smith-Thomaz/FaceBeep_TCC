//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusDoUsuarioService } from '../statusdousuario.service';

@Component({
    selector: 'app-statusdousuario-container-filter',
    templateUrl: './statusdousuario-container-filter.component.html',
    styleUrls: ['./statusdousuario-container-filter.component.css'],
})
export class StatusDoUsuarioContainerFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private statusDoUsuarioService: StatusDoUsuarioService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusDoUsuarioService.initVM();
    }

    ngOnInit() {

       
    }

}
