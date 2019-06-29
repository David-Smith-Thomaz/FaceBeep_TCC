import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusRegisterService } from '../statusregister.service';

@Component({
    selector: 'app-statusregister-details',
    templateUrl: './statusregister-details.component.html',
    styleUrls: ['./statusregister-details.component.css'],
})
export class StatusRegisterDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusRegisterService: StatusRegisterService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusRegisterService.initVM();

    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id) {
            this.statusRegisterService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            })
        };
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.statusRegisterService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.statusRegisterService.getInfoGrid(infos);
        });
    }

    
}
