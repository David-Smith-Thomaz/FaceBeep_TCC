//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { RegisterService } from '../register.service';

@Component({
    selector: 'app-register-container-edit',
    templateUrl: './register-container-edit.component.html',
    styleUrls: ['./register-container-edit.component.css'],
})
export class RegisterContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private registerService: RegisterService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.registerService.initVM();
    }

    ngOnInit() {

       
    }

}
