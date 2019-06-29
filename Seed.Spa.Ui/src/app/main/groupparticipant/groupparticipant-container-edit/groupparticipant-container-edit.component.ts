//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { GroupParticipantService } from '../groupparticipant.service';

@Component({
    selector: 'app-groupparticipant-container-edit',
    templateUrl: './groupparticipant-container-edit.component.html',
    styleUrls: ['./groupparticipant-container-edit.component.css'],
})
export class GroupParticipantContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private groupParticipantService: GroupParticipantService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.groupParticipantService.initVM();
    }

    ngOnInit() {

       
    }

}
