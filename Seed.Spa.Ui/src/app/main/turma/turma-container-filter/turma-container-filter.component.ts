//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TurmaService } from '../turma.service';

@Component({
    selector: 'app-turma-container-filter',
    templateUrl: './turma-container-filter.component.html',
    styleUrls: ['./turma-container-filter.component.css'],
})
export class TurmaContainerFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private turmaService: TurmaService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.turmaService.initVM();
    }

    ngOnInit() {

       
    }

}
