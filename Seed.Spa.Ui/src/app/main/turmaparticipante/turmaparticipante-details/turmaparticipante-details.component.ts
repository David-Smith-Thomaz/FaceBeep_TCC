import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { TurmaParticipanteService } from '../turmaparticipante.service';

@Component({
    selector: 'app-turmaparticipante-details',
    templateUrl: './turmaparticipante-details.component.html',
    styleUrls: ['./turmaparticipante-details.component.css'],
})
export class TurmaParticipanteDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private turmaParticipanteService: TurmaParticipanteService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.turmaParticipanteService.initVM();

    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id) {
            this.turmaParticipanteService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            })
        };
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.turmaParticipanteService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.turmaParticipanteService.getInfoGrid(infos);
        });
    }

    
}
