import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { TurmaService } from '../turma.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-turma-print',
    templateUrl: './turma-print.component.html',
    styleUrls: ['./turma-print.component.css'],
})
export class TurmaPrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private turmaService: TurmaService, private route: ActivatedRoute) {
        this.vm = this.turmaService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.turmaService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }
        
        this.updateCulture();

    }
    
	updateCulture(culture: string = null) {
        this.turmaService.updateCulture(culture).then((infos: any) => {
					this.vm.infos = infos;
					this.vm.grid = this.turmaService.getInfoGrid(infos);
        });
        this.turmaService.updateCultureMain(culture).then((infos: any) => {
					this.vm.generalInfo = infos;
        });
    }
    
    onPrint() {
        window.print();
    }
   


}
