//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusUserService } from '../statususer.service';

@Component({
    selector: 'app-statususer-container-create',
    templateUrl: './statususer-container-create.component.html',
    styleUrls: ['./statususer-container-create.component.css'],
})
export class StatusUserContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private statusUserService: StatusUserService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusUserService.initVM();
    }

    ngOnInit() {

       
    }

}
