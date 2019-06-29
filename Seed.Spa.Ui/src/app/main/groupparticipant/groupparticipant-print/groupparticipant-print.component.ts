import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { GroupParticipantService } from '../groupparticipant.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-groupparticipant-print',
    templateUrl: './groupparticipant-print.component.html',
    styleUrls: ['./groupparticipant-print.component.css'],
})
export class GroupParticipantPrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private groupParticipantService: GroupParticipantService, private route: ActivatedRoute) {
        this.vm = this.groupParticipantService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.groupParticipantService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }
        
        this.updateCulture();

    }
    
	updateCulture(culture: string = null) {
        this.groupParticipantService.updateCulture(culture).then((infos: any) => {
					this.vm.infos = infos;
					this.vm.grid = this.groupParticipantService.getInfoGrid(infos);
        });
        this.groupParticipantService.updateCultureMain(culture).then((infos: any) => {
					this.vm.generalInfo = infos;
        });
    }
    
    onPrint() {
        window.print();
    }
   


}
