import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { StatusDoUsuarioService } from '../statusdousuario.service';

@Component({
    selector: 'app-statusdousuario-details',
    templateUrl: './statusdousuario-details.component.html',
    styleUrls: ['./statusdousuario-details.component.css'],
})
export class StatusDoUsuarioDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusDoUsuarioService: StatusDoUsuarioService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.statusDoUsuarioService.initVM();

    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id) {
            this.statusDoUsuarioService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            })
        };
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.statusDoUsuarioService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.statusDoUsuarioService.getInfoGrid(infos);
        });
    }

    
}
