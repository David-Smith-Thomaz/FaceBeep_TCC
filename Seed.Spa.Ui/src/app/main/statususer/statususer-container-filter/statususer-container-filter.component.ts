//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusUserService } from '../statususer.service';

@Component({
    selector: 'app-statususer-container-filter',
    templateUrl: './statususer-container-filter.component.html',
    styleUrls: ['./statususer-container-filter.component.css'],
})
export class StatusUserContainerFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private statusUserService: StatusUserService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusUserService.initVM();
    }

    ngOnInit() {

       
    }

}
