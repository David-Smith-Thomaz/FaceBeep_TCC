//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusUserService } from '../statususer.service';

@Component({
    selector: 'app-statususer-container-edit',
    templateUrl: './statususer-container-edit.component.html',
    styleUrls: ['./statususer-container-edit.component.css'],
})
export class StatusUserContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusUserService: StatusUserService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusUserService.initVM();
    }

    ngOnInit() {

       
    }

}
