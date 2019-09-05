import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { StatusCodigoService } from '../statuscodigo.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-statuscodigo-print',
    templateUrl: './statuscodigo-print.component.html',
    styleUrls: ['./statuscodigo-print.component.css'],
})
export class StatusCodigoPrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusCodigoService: StatusCodigoService, private route: ActivatedRoute) {
        this.vm = this.statusCodigoService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.statusCodigoService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }
        
        this.updateCulture();

    }
    
	updateCulture(culture: string = null) {
        this.statusCodigoService.updateCulture(culture).then((infos: any) => {
					this.vm.infos = infos;
					this.vm.grid = this.statusCodigoService.getInfoGrid(infos);
        });
        this.statusCodigoService.updateCultureMain(culture).then((infos: any) => {
					this.vm.generalInfo = infos;
        });
    }
    
    onPrint() {
        window.print();
    }
   


}
