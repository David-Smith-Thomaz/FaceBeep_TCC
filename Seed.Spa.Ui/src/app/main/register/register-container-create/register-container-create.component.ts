//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { RegisterService } from '../register.service';

@Component({
    selector: 'app-register-container-create',
    templateUrl: './register-container-create.component.html',
    styleUrls: ['./register-container-create.component.css'],
})
export class RegisterContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private registerService: RegisterService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.registerService.initVM();
    }

    ngOnInit() {

       
    }

}
