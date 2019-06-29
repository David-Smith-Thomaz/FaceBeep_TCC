import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class StatusRegisterServiceFields extends ServiceBase {


    constructor() {
		super()
	}

	getKey() {
		return "StatusRegister";
	}

	getFormControls(moreFormControls? : any) {
		var formControls = Object.assign({
            description : new FormControl(),
            statusRegisterId : new FormControl(),
        },moreFormControls || {});
		return formControls;
	}

	getFormFields(moreFormControls?: any) {
		return new FormGroup(this.getFormControls(moreFormControls));
	}

	getInfosFields(moreInfosFields? : any, orderByMore = false) {
		var defaultInfosFields = {
                    description: { label: 'description', type: 'string', isKey: false, list:true   },
                    statusRegisterId: { label: 'statusRegisterId', type: 'int', isKey: true, list:false   },
        };
		return this.mergeInfoFields(defaultInfosFields, moreInfosFields, orderByMore);
    }

}
