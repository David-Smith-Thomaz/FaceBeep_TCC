import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TypeUserService } from '../typeuser.service';

@Component({
    selector: 'app-typeuser-details',
    templateUrl: './typeuser-details.component.html',
    styleUrls: ['./typeuser-details.component.css'],
})
export class TypeUserDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private typeUserService: TypeUserService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.typeUserService.initVM();

    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id) {
            this.typeUserService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            })
        };
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.typeUserService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.typeUserService.getInfoGrid(infos);
        });
    }

    
}
