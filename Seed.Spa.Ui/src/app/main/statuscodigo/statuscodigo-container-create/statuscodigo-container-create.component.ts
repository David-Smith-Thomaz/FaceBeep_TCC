//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusCodigoService } from '../statuscodigo.service';

@Component({
    selector: 'app-statuscodigo-container-create',
    templateUrl: './statuscodigo-container-create.component.html',
    styleUrls: ['./statuscodigo-container-create.component.css'],
})
export class StatusCodigoContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private statusCodigoService: StatusCodigoService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusCodigoService.initVM();
    }

    ngOnInit() {

       
    }

}
