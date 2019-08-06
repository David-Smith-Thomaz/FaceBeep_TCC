import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { StatusDoUsuarioService } from '../statusdousuario.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-statusdousuario-print',
    templateUrl: './statusdousuario-print.component.html',
    styleUrls: ['./statusdousuario-print.component.css'],
})
export class StatusDoUsuarioPrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusDoUsuarioService: StatusDoUsuarioService, private route: ActivatedRoute) {
        this.vm = this.statusDoUsuarioService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.statusDoUsuarioService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }
        
        this.updateCulture();

    }
    
	updateCulture(culture: string = null) {
        this.statusDoUsuarioService.updateCulture(culture).then((infos: any) => {
					this.vm.infos = infos;
					this.vm.grid = this.statusDoUsuarioService.getInfoGrid(infos);
        });
        this.statusDoUsuarioService.updateCultureMain(culture).then((infos: any) => {
					this.vm.generalInfo = infos;
        });
    }
    
    onPrint() {
        window.print();
    }
   


}
