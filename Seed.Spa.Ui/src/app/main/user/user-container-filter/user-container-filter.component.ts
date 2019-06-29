//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { UserService } from '../user.service';

@Component({
    selector: 'app-user-container-filter',
    templateUrl: './user-container-filter.component.html',
    styleUrls: ['./user-container-filter.component.css'],
})
export class UserContainerFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private userService: UserService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.userService.initVM();
    }

    ngOnInit() {

       
    }

}
