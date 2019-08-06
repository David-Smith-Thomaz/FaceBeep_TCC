import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { ParticipanteService } from '../participante.service';

@Component({
    selector: 'app-participante-details',
    templateUrl: './participante-details.component.html',
    styleUrls: ['./participante-details.component.css'],
})
export class ParticipanteDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private participanteService: ParticipanteService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.participanteService.initVM();

    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id) {
            this.participanteService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            })
        };
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.participanteService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.participanteService.getInfoGrid(infos);
        });
    }

    
}
