import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class ParticipantServiceFields extends ServiceBase {


    constructor() {
		super()
	}

	getKey() {
		return "Participant";
	}

	getFormControls(moreFormControls? : any) {
		var formControls = Object.assign({
            photoPerfil : new FormControl(),
            name : new FormControl(),
            description : new FormControl(),
            participantId : new FormControl(),
            userId : new FormControl(),
            groupParticipantId : new FormControl(),
            documentNumber : new FormControl(),
        },moreFormControls || {});
		return formControls;
	}

	getFormFields(moreFormControls?: any) {
		return new FormGroup(this.getFormControls(moreFormControls));
	}

	getInfosFields(moreInfosFields? : any, orderByMore = false) {
		var defaultInfosFields = {
                    photoPerfil: { label: 'photoPerfil', type: 'string', isKey: false, list:true   },
                    name: { label: 'name', type: 'string', isKey: false, list:true   },
                    description: { label: 'description', type: 'string', isKey: false, list:false   },
                    participantId: { label: 'participantId', type: 'int', isKey: true, list:false   },
                    userId: { label: 'userId', type: 'int', isKey: false, list:true   },
                    groupParticipantId: { label: 'groupParticipantId', type: 'int?', isKey: false, list:true   },
                    documentNumber: { label: 'documentNumber', type: 'int', isKey: false, list:true   },
        };
		return this.mergeInfoFields(defaultInfosFields, moreInfosFields, orderByMore);
    }

}
