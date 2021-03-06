﻿//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusDaTurmaService } from '../statusdaturma.service';

@Component({
    selector: 'app-statusdaturma-container-filter',
    templateUrl: './statusdaturma-container-filter.component.html',
    styleUrls: ['./statusdaturma-container-filter.component.css'],
})
export class StatusDaTurmaContainerFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private statusDaTurmaService: StatusDaTurmaService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusDaTurmaService.initVM();
    }

    ngOnInit() {

       
    }

}
