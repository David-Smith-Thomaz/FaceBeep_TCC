import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusCodigoService } from '../statuscodigo.service';

@Component({
    selector: 'app-statuscodigo-details',
    templateUrl: './statuscodigo-details.component.html',
    styleUrls: ['./statuscodigo-details.component.css'],
})
export class StatusCodigoDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusCodigoService: StatusCodigoService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusCodigoService.initVM();

    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id) {
            this.statusCodigoService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            })
        };
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.statusCodigoService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.statusCodigoService.getInfoGrid(infos);
        });
    }

    
}
