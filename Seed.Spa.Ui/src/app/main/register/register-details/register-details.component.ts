import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { RegisterService } from '../register.service';

@Component({
    selector: 'app-register-details',
    templateUrl: './register-details.component.html',
    styleUrls: ['./register-details.component.css'],
})
export class RegisterDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private registerService: RegisterService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.registerService.initVM();

    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id) {
            this.registerService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            })
        };
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.registerService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.registerService.getInfoGrid(infos);
        });
    }

    
}
