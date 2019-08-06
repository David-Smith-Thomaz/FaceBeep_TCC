import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusDaTurmaService } from '../statusdaturma.service';

@Component({
    selector: 'app-statusdaturma-details',
    templateUrl: './statusdaturma-details.component.html',
    styleUrls: ['./statusdaturma-details.component.css'],
})
export class StatusDaTurmaDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusDaTurmaService: StatusDaTurmaService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusDaTurmaService.initVM();

    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id) {
            this.statusDaTurmaService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            })
        };
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.statusDaTurmaService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.statusDaTurmaService.getInfoGrid(infos);
        });
    }

    
}
