//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusCodigoService } from '../statuscodigo.service';

@Component({
    selector: 'app-statuscodigo-container-filter',
    templateUrl: './statuscodigo-container-filter.component.html',
    styleUrls: ['./statuscodigo-container-filter.component.css'],
})
export class StatusCodigoContainerFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private statusCodigoService: StatusCodigoService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusCodigoService.initVM();
    }

    ngOnInit() {

       
    }

}
