//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TypeUserService } from '../typeuser.service';

@Component({
    selector: 'app-typeuser-container-edit',
    templateUrl: './typeuser-container-edit.component.html',
    styleUrls: ['./typeuser-container-edit.component.css'],
})
export class TypeUserContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private typeUserService: TypeUserService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.typeUserService.initVM();
    }

    ngOnInit() {

       
    }

}
