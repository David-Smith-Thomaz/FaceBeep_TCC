//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { ParticipantService } from '../participant.service';

@Component({
    selector: 'app-participant-container-details',
    templateUrl: './participant-container-details.component.html',
    styleUrls: ['./participant-container-details.component.css'],
})
export class ParticipantContainerDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private participantService: ParticipantService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.participantService.initVM();
    }

    ngOnInit() {

       
    }

}
