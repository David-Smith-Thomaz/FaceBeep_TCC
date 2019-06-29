//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { UserService } from '../user.service';

@Component({
    selector: 'app-user-container-edit',
    templateUrl: './user-container-edit.component.html',
    styleUrls: ['./user-container-edit.component.css'],
})
export class UserContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private userService: UserService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.userService.initVM();
    }

    ngOnInit() {

       
    }

}
