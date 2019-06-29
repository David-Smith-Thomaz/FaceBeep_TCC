import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { ParticipantService } from '../participant.service';

@Component({
    selector: 'app-participant-details',
    templateUrl: './participant-details.component.html',
    styleUrls: ['./participant-details.component.css'],
})
export class ParticipantDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private participantService: ParticipantService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.participantService.initVM();

    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id) {
            this.participantService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            })
        };
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.participantService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.participantService.getInfoGrid(infos);
        });
    }

    
}
