//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusRegisterService } from '../statusregister.service';

@Component({
    selector: 'app-statusregister-container-create',
    templateUrl: './statusregister-container-create.component.html',
    styleUrls: ['./statusregister-container-create.component.css'],
})
export class StatusRegisterContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private statusRegisterService: StatusRegisterService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusRegisterService.initVM();
    }

    ngOnInit() {

       
    }

}
