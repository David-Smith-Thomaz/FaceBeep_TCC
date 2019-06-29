//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { RegisterService } from '../register.service';

@Component({
    selector: 'app-register-container-details',
    templateUrl: './register-container-details.component.html',
    styleUrls: ['./register-container-details.component.css'],
})
export class RegisterContainerDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private registerService: RegisterService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.registerService.initVM();
    }

    ngOnInit() {

       
    }

}
