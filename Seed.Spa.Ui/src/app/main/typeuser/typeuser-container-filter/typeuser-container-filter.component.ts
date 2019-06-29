//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TypeUserService } from '../typeuser.service';

@Component({
    selector: 'app-typeuser-container-filter',
    templateUrl: './typeuser-container-filter.component.html',
    styleUrls: ['./typeuser-container-filter.component.css'],
})
export class TypeUserContainerFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private typeUserService: TypeUserService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.typeUserService.initVM();
    }

    ngOnInit() {

       
    }

}
