import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class UserServiceFields extends ServiceBase {


    constructor() {
		super()
	}

	getKey() {
		return "User";
	}

	getFormControls(moreFormControls? : any) {
		var formControls = Object.assign({
            login : new FormControl(),
            password : new FormControl(),
            userId : new FormControl(),
            statusUserId : new FormControl(),
            typeUserId : new FormControl(),
        },moreFormControls || {});
		return formControls;
	}

	getFormFields(moreFormControls?: any) {
		return new FormGroup(this.getFormControls(moreFormControls));
	}

	getInfosFields(moreInfosFields? : any, orderByMore = false) {
		var defaultInfosFields = {
                    login: { label: 'login', type: 'string', isKey: false, list:true   },
                    password: { label: 'password', type: 'string', isKey: false, list:true   },
                    userId: { label: 'userId', type: 'int', isKey: true, list:false   },
                    statusUserId: { label: 'statusUserId', type: 'int', isKey: false, list:true   },
                    typeUserId: { label: 'typeUserId', type: 'int', isKey: false, list:true   },
        };
		return this.mergeInfoFields(defaultInfosFields, moreInfosFields, orderByMore);
    }

}
