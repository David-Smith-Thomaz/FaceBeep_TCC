import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { TipoDeUsuarioService } from '../tipodeusuario.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-tipodeusuario-print',
    templateUrl: './tipodeusuario-print.component.html',
    styleUrls: ['./tipodeusuario-print.component.css'],
})
export class TipoDeUsuarioPrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private tipoDeUsuarioService: TipoDeUsuarioService, private route: ActivatedRoute) {
        this.vm = this.tipoDeUsuarioService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.tipoDeUsuarioService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }
        
        this.updateCulture();

    }
    
	updateCulture(culture: string = null) {
        this.tipoDeUsuarioService.updateCulture(culture).then((infos: any) => {
					this.vm.infos = infos;
					this.vm.grid = this.tipoDeUsuarioService.getInfoGrid(infos);
        });
        this.tipoDeUsuarioService.updateCultureMain(culture).then((infos: any) => {
					this.vm.generalInfo = infos;
        });
    }
    
    onPrint() {
        window.print();
    }
   


}
