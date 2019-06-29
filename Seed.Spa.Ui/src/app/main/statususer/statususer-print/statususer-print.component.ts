import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { StatusUserService } from '../statususer.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-statususer-print',
    templateUrl: './statususer-print.component.html',
    styleUrls: ['./statususer-print.component.css'],
})
export class StatusUserPrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusUserService: StatusUserService, private route: ActivatedRoute) {
        this.vm = this.statusUserService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.statusUserService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }
        
        this.updateCulture();

    }
    
	updateCulture(culture: string = null) {
        this.statusUserService.updateCulture(culture).then((infos: any) => {
					this.vm.infos = infos;
					this.vm.grid = this.statusUserService.getInfoGrid(infos);
        });
        this.statusUserService.updateCultureMain(culture).then((infos: any) => {
					this.vm.generalInfo = infos;
        });
    }
    
    onPrint() {
        window.print();
    }
   


}
