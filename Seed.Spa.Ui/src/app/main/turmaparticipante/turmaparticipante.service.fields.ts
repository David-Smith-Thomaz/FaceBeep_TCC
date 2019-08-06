import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class TurmaParticipanteServiceFields extends ServiceBase {


    constructor() {
		super()
	}

	getKey() {
		return "TurmaParticipante";
	}

	getFormControls(moreFormControls? : any) {
		var formControls = Object.assign({
            turmaParticipanteId : new FormControl(),
            participanteId : new FormControl(),
            turmaId : new FormControl(),
        },moreFormControls || {});
		return formControls;
	}

	getFormFields(moreFormControls?: any) {
		return new FormGroup(this.getFormControls(moreFormControls));
	}

	getInfosFields(moreInfosFields? : any, orderByMore = false) {
		var defaultInfosFields = {
                    turmaParticipanteId: { label: 'turmaParticipanteId', type: 'int', isKey: true, list:false   },
                    participanteId: { label: 'participanteId', type: 'int', isKey: false, list:true   },
                    turmaId: { label: 'turmaId', type: 'int', isKey: false, list:true   },
        };
		return this.mergeInfoFields(defaultInfosFields, moreInfosFields, orderByMore);
    }

}
