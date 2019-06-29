import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class StatusUserServiceFields extends ServiceBase {


    constructor() {
		super()
	}

	getKey() {
		return "StatusUser";
	}

	getFormControls(moreFormControls? : any) {
		var formControls = Object.assign({
            description : new FormControl(),
            statusUserId : new FormControl(),
        },moreFormControls || {});
		return formControls;
	}

	getFormFields(moreFormControls?: any) {
		return new FormGroup(this.getFormControls(moreFormControls));
	}

	getInfosFields(moreInfosFields? : any, orderByMore = false) {
		var defaultInfosFields = {
                    description: { label: 'description', type: 'string', isKey: false, list:true   },
                    statusUserId: { label: 'statusUserId', type: 'int', isKey: true, list:false   },
        };
		return this.mergeInfoFields(defaultInfosFields, moreInfosFields, orderByMore);
    }

}
