//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusCodigoService } from '../statuscodigo.service';

@Component({
    selector: 'app-statuscodigo-container-details',
    templateUrl: './statuscodigo-container-details.component.html',
    styleUrls: ['./statuscodigo-container-details.component.css'],
})
export class StatusCodigoContainerDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusCodigoService: StatusCodigoService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusCodigoService.initVM();
    }

    ngOnInit() {

       
    }

}
