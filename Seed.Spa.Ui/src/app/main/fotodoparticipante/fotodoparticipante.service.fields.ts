import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class FotoDoParticipanteServiceFields extends ServiceBase {


    constructor() {
		super()
	}

	getKey() {
		return "FotoDoParticipante";
	}

	getFormControls(moreFormControls? : any) {
		var formControls = Object.assign({
            fotoDoParticipateId : new FormControl(),
        },moreFormControls || {});
		return formControls;
	}

	getFormFields(moreFormControls?: any) {
		return new FormGroup(this.getFormControls(moreFormControls));
	}

	getInfosFields(moreInfosFields? : any, orderByMore = false) {
		var defaultInfosFields = {
                    fotoDoParticipateId: { label: 'fotoDoParticipateId', type: 'string', isKey: true, list:false   },
        };
		return this.mergeInfoFields(defaultInfosFields, moreInfosFields, orderByMore);
    }

}
