//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { GroupParticipantService } from '../groupparticipant.service';

@Component({
    selector: 'app-groupparticipant-container-details',
    templateUrl: './groupparticipant-container-details.component.html',
    styleUrls: ['./groupparticipant-container-details.component.css'],
})
export class GroupParticipantContainerDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private groupParticipantService: GroupParticipantService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.groupParticipantService.initVM();
    }

    ngOnInit() {

       
    }

}
