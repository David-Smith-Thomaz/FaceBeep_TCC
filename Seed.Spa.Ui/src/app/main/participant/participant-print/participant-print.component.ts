import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { ParticipantService } from '../participant.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-participant-print',
    templateUrl: './participant-print.component.html',
    styleUrls: ['./participant-print.component.css'],
})
export class ParticipantPrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private participantService: ParticipantService, private route: ActivatedRoute) {
        this.vm = this.participantService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.participantService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }
        
        this.updateCulture();

    }
    
	updateCulture(culture: string = null) {
        this.participantService.updateCulture(culture).then((infos: any) => {
					this.vm.infos = infos;
					this.vm.grid = this.participantService.getInfoGrid(infos);
        });
        this.participantService.updateCultureMain(culture).then((infos: any) => {
					this.vm.generalInfo = infos;
        });
    }
    
    onPrint() {
        window.print();
    }
   


}
