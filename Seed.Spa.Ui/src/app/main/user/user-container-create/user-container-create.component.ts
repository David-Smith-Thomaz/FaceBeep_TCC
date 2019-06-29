//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { UserService } from '../user.service';

@Component({
    selector: 'app-user-container-create',
    templateUrl: './user-container-create.component.html',
    styleUrls: ['./user-container-create.component.css'],
})
export class UserContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private userService: UserService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.userService.initVM();
    }

    ngOnInit() {

       
    }

}
