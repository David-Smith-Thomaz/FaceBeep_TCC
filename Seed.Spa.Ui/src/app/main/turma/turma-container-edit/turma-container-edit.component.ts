//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TurmaService } from '../turma.service';

@Component({
    selector: 'app-turma-container-edit',
    templateUrl: './turma-container-edit.component.html',
    styleUrls: ['./turma-container-edit.component.css'],
})
export class TurmaContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private turmaService: TurmaService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.turmaService.initVM();
    }

    ngOnInit() {

       
    }

}
