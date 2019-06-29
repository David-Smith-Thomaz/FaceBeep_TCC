import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class RegisterServiceFields extends ServiceBase {


    constructor() {
		super()
	}

	getKey() {
		return "Register";
	}

	getFormControls(moreFormControls? : any) {
		var formControls = Object.assign({
            description : new FormControl(),
            enterDate : new FormControl(),
            exitDate : new FormControl(),
            registerId : new FormControl(),
            statusRegisterId : new FormControl(),
            participantId : new FormControl(),
        },moreFormControls || {});
		return formControls;
	}

	getFormFields(moreFormControls?: any) {
		return new FormGroup(this.getFormControls(moreFormControls));
	}

	getInfosFields(moreInfosFields? : any, orderByMore = false) {
		var defaultInfosFields = {
                    description: { label: 'description', type: 'string', isKey: false, list:false   },
                    enterDate: { label: 'enterDate', type: 'DateTime', isKey: false, list:true   },
                    exitDate: { label: 'exitDate', type: 'DateTime', isKey: false, list:true   },
                    registerId: { label: 'registerId', type: 'int', isKey: true, list:false   },
                    statusRegisterId: { label: 'statusRegisterId', type: 'int', isKey: false, list:true   },
                    participantId: { label: 'participantId', type: 'int', isKey: false, list:true   },
        };
		return this.mergeInfoFields(defaultInfosFields, moreInfosFields, orderByMore);
    }

}
