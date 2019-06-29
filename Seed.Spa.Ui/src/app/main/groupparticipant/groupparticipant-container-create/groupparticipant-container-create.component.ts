//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { GroupParticipantService } from '../groupparticipant.service';

@Component({
    selector: 'app-groupparticipant-container-create',
    templateUrl: './groupparticipant-container-create.component.html',
    styleUrls: ['./groupparticipant-container-create.component.css'],
})
export class GroupParticipantContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private groupParticipantService: GroupParticipantService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.groupParticipantService.initVM();
    }

    ngOnInit() {

       
    }

}
