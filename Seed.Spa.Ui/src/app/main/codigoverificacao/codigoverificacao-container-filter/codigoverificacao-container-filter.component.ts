//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { CodigoVerificacaoService } from '../codigoverificacao.service';

@Component({
    selector: 'app-codigoverificacao-container-filter',
    templateUrl: './codigoverificacao-container-filter.component.html',
    styleUrls: ['./codigoverificacao-container-filter.component.css'],
})
export class CodigoVerificacaoContainerFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private codigoVerificacaoService: CodigoVerificacaoService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.codigoVerificacaoService.initVM();
    }

    ngOnInit() {

       
    }

}
