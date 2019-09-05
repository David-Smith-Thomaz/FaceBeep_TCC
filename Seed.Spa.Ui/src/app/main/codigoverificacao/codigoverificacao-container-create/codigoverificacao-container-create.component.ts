//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { CodigoVerificacaoService } from '../codigoverificacao.service';

@Component({
    selector: 'app-codigoverificacao-container-create',
    templateUrl: './codigoverificacao-container-create.component.html',
    styleUrls: ['./codigoverificacao-container-create.component.css'],
})
export class CodigoVerificacaoContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private codigoVerificacaoService: CodigoVerificacaoService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.codigoVerificacaoService.initVM();
    }

    ngOnInit() {

       
    }

}
