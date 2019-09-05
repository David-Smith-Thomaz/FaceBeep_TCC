//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusCodigoService } from '../statuscodigo.service';

@Component({
    selector: 'app-statuscodigo-container-edit',
    templateUrl: './statuscodigo-container-edit.component.html',
    styleUrls: ['./statuscodigo-container-edit.component.css'],
})
export class StatusCodigoContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusCodigoService: StatusCodigoService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusCodigoService.initVM();
    }

    ngOnInit() {

       
    }

}
