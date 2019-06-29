//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { ParticipantService } from '../participant.service';

@Component({
    selector: 'app-participant-container-create',
    templateUrl: './participant-container-create.component.html',
    styleUrls: ['./participant-container-create.component.css'],
})
export class ParticipantContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private participantService: ParticipantService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.participantService.initVM();
    }

    ngOnInit() {

       
    }

}
