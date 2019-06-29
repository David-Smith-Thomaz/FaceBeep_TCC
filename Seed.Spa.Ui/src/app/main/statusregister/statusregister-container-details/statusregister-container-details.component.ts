//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusRegisterService } from '../statusregister.service';

@Component({
    selector: 'app-statusregister-container-details',
    templateUrl: './statusregister-container-details.component.html',
    styleUrls: ['./statusregister-container-details.component.css'],
})
export class StatusRegisterContainerDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusRegisterService: StatusRegisterService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusRegisterService.initVM();
    }

    ngOnInit() {

       
    }

}
