import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusUserService } from '../statususer.service';

@Component({
    selector: 'app-statususer-details',
    templateUrl: './statususer-details.component.html',
    styleUrls: ['./statususer-details.component.css'],
})
export class StatusUserDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusUserService: StatusUserService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusUserService.initVM();

    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id) {
            this.statusUserService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            })
        };
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.statusUserService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.statusUserService.getInfoGrid(infos);
        });
    }

    
}
