import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { TypeUserService } from '../typeuser.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-typeuser-print',
    templateUrl: './typeuser-print.component.html',
    styleUrls: ['./typeuser-print.component.css'],
})
export class TypeUserPrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private typeUserService: TypeUserService, private route: ActivatedRoute) {
        this.vm = this.typeUserService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.typeUserService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }
        
        this.updateCulture();

    }
    
	updateCulture(culture: string = null) {
        this.typeUserService.updateCulture(culture).then((infos: any) => {
					this.vm.infos = infos;
					this.vm.grid = this.typeUserService.getInfoGrid(infos);
        });
        this.typeUserService.updateCultureMain(culture).then((infos: any) => {
					this.vm.generalInfo = infos;
        });
    }
    
    onPrint() {
        window.print();
    }
   


}
