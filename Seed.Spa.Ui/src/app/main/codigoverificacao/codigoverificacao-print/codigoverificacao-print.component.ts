import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { CodigoVerificacaoService } from '../codigoverificacao.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-codigoverificacao-print',
    templateUrl: './codigoverificacao-print.component.html',
    styleUrls: ['./codigoverificacao-print.component.css'],
})
export class CodigoVerificacaoPrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private codigoVerificacaoService: CodigoVerificacaoService, private route: ActivatedRoute) {
        this.vm = this.codigoVerificacaoService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.codigoVerificacaoService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }
        
        this.updateCulture();

    }
    
	updateCulture(culture: string = null) {
        this.codigoVerificacaoService.updateCulture(culture).then((infos: any) => {
					this.vm.infos = infos;
					this.vm.grid = this.codigoVerificacaoService.getInfoGrid(infos);
        });
        this.codigoVerificacaoService.updateCultureMain(culture).then((infos: any) => {
					this.vm.generalInfo = infos;
        });
    }
    
    onPrint() {
        window.print();
    }
   


}
