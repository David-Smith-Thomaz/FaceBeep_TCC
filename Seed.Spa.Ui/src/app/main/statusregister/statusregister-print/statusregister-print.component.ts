import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { StatusRegisterService } from '../statusregister.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-statusregister-print',
    templateUrl: './statusregister-print.component.html',
    styleUrls: ['./statusregister-print.component.css'],
})
export class StatusRegisterPrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusRegisterService: StatusRegisterService, private route: ActivatedRoute) {
        this.vm = this.statusRegisterService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.statusRegisterService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }
        
        this.updateCulture();

    }
    
	updateCulture(culture: string = null) {
        this.statusRegisterService.updateCulture(culture).then((infos: any) => {
					this.vm.infos = infos;
					this.vm.grid = this.statusRegisterService.getInfoGrid(infos);
        });
        this.statusRegisterService.updateCultureMain(culture).then((infos: any) => {
					this.vm.generalInfo = infos;
        });
    }
    
    onPrint() {
        window.print();
    }
   


}
