﻿import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class TipoDeParticipanteServiceFields extends ServiceBase {


    constructor() {
		super()
	}

	getKey() {
		return "TipoDeParticipante";
	}

	getFormControls(moreFormControls? : any) {
		var formControls = Object.assign({
            descricao : new FormControl(),
            tipoDeParticipanteId : new FormControl(),
        },moreFormControls || {});
		return formControls;
	}

	getFormFields(moreFormControls?: any) {
		return new FormGroup(this.getFormControls(moreFormControls));
	}

	getInfosFields(moreInfosFields? : any, orderByMore = false) {
		var defaultInfosFields = {
                    descricao: { label: 'descricao', type: 'string', isKey: false, list:true   },
                    tipoDeParticipanteId: { label: 'tipoDeParticipanteId', type: 'int', isKey: true, list:false   },
        };
		return this.mergeInfoFields(defaultInfosFields, moreInfosFields, orderByMore);
    }

}
