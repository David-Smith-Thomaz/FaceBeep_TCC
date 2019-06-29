//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusUserService } from '../statususer.service';

@Component({
    selector: 'app-statususer-container-details',
    templateUrl: './statususer-container-details.component.html',
    styleUrls: ['./statususer-container-details.component.css'],
})
export class StatusUserContainerDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusUserService: StatusUserService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusUserService.initVM();
    }

    ngOnInit() {

       
    }

}
