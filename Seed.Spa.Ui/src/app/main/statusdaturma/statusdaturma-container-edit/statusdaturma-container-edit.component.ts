//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusDaTurmaService } from '../statusdaturma.service';

@Component({
    selector: 'app-statusdaturma-container-edit',
    templateUrl: './statusdaturma-container-edit.component.html',
    styleUrls: ['./statusdaturma-container-edit.component.css'],
})
export class StatusDaTurmaContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusDaTurmaService: StatusDaTurmaService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusDaTurmaService.initVM();
    }

    ngOnInit() {

       
    }

}
