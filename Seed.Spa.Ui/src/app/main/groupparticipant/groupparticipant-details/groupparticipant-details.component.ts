import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { GroupParticipantService } from '../groupparticipant.service';

@Component({
    selector: 'app-groupparticipant-details',
    templateUrl: './groupparticipant-details.component.html',
    styleUrls: ['./groupparticipant-details.component.css'],
})
export class GroupParticipantDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private groupParticipantService: GroupParticipantService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.groupParticipantService.initVM();

    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id) {
            this.groupParticipantService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            })
        };
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.groupParticipantService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.groupParticipantService.getInfoGrid(infos);
        });
    }

    
}
