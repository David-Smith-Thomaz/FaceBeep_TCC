import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { StatusDaTurmaService } from '../statusdaturma.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-statusdaturma-print',
    templateUrl: './statusdaturma-print.component.html',
    styleUrls: ['./statusdaturma-print.component.css'],
})
export class StatusDaTurmaPrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private statusDaTurmaService: StatusDaTurmaService, private route: ActivatedRoute) {
        this.vm = this.statusDaTurmaService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.statusDaTurmaService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }
        
        this.updateCulture();

    }
    
	updateCulture(culture: string = null) {
        this.statusDaTurmaService.updateCulture(culture).then((infos: any) => {
					this.vm.infos = infos;
					this.vm.grid = this.statusDaTurmaService.getInfoGrid(infos);
        });
        this.statusDaTurmaService.updateCultureMain(culture).then((infos: any) => {
					this.vm.generalInfo = infos;
        });
    }
    
    onPrint() {
        window.print();
    }
   


}
