import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TipoDeUsuarioService } from '../tipodeusuario.service';

@Component({
    selector: 'app-tipodeusuario-details',
    templateUrl: './tipodeusuario-details.component.html',
    styleUrls: ['./tipodeusuario-details.component.css'],
})
export class TipoDeUsuarioDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private tipoDeUsuarioService: TipoDeUsuarioService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.tipoDeUsuarioService.initVM();

    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id) {
            this.tipoDeUsuarioService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            })
        };
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.tipoDeUsuarioService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.tipoDeUsuarioService.getInfoGrid(infos);
        });
    }

    
}
