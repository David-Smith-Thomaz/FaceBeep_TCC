import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class CodigoVerificacaoServiceFields extends ServiceBase {


    constructor() {
		super()
	}

	getKey() {
		return "CodigoVerificacao";
	}

	getFormControls(moreFormControls? : any) {
		var formControls = Object.assign({
            codigo : new FormControl(),
            dataInicio : new FormControl(),
            dataFim : new FormControl(),
            codigoVerificacaoId : new FormControl(),
            participanteId : new FormControl(),
            statusCodigoId : new FormControl(),
        },moreFormControls || {});
		return formControls;
	}

	getFormFields(moreFormControls?: any) {
		return new FormGroup(this.getFormControls(moreFormControls));
	}

	getInfosFields(moreInfosFields? : any, orderByMore = false) {
		var defaultInfosFields = {
                    codigo: { label: 'codigo', type: 'Guid', isKey: false, list:true   },
                    dataInicio: { label: 'dataInicio', type: 'DateTime', isKey: false, list:true   },
                    dataFim: { label: 'dataFim', type: 'DateTime', isKey: false, list:true   },
                    codigoVerificacaoId: { label: 'codigoVerificacaoId', type: 'int', isKey: true, list:false   },
                    participanteId: { label: 'participanteId', type: 'int', isKey: false, list:true   },
                    statusCodigoId: { label: 'statusCodigoId', type: 'int', isKey: false, list:true   },
        };
		return this.mergeInfoFields(defaultInfosFields, moreInfosFields, orderByMore);
    }

}
