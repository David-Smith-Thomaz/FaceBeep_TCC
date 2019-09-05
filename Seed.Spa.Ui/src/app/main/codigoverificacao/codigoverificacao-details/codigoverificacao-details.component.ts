import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { CodigoVerificacaoService } from '../codigoverificacao.service';

@Component({
    selector: 'app-codigoverificacao-details',
    templateUrl: './codigoverificacao-details.component.html',
    styleUrls: ['./codigoverificacao-details.component.css'],
})
export class CodigoVerificacaoDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private codigoVerificacaoService: CodigoVerificacaoService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.codigoVerificacaoService.initVM();

    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id) {
            this.codigoVerificacaoService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            })
        };
        this.updateCulture();
    }
    
    updateCulture(culture: string = null) {
        this.codigoVerificacaoService.updateCulture(culture).then((infos: any) => {
            this.vm.infos = infos;
            this.vm.grid = this.codigoVerificacaoService.getInfoGrid(infos);
        });
    }

    
}
