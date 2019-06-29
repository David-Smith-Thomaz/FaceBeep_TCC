import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class GroupParticipantServiceFields extends ServiceBase {


    constructor() {
		super()
	}

	getKey() {
		return "GroupParticipant";
	}

	getFormControls(moreFormControls? : any) {
		var formControls = Object.assign({
            groupName : new FormControl(),
            startDatePeriod : new FormControl(),
            endDatePeriod : new FormControl(),
            groupParticipantId : new FormControl(),
            active : new FormControl(),
        },moreFormControls || {});
		return formControls;
	}

	getFormFields(moreFormControls?: any) {
		return new FormGroup(this.getFormControls(moreFormControls));
	}

	getInfosFields(moreInfosFields? : any, orderByMore = false) {
		var defaultInfosFields = {
                    groupName: { label: 'groupName', type: 'string', isKey: false, list:true   },
                    startDatePeriod: { label: 'startDatePeriod', type: 'DateTime', isKey: false, list:true   },
                    endDatePeriod: { label: 'endDatePeriod', type: 'DateTime', isKey: false, list:true   },
                    groupParticipantId: { label: 'groupParticipantId', type: 'int', isKey: true, list:false   },
                    active: { label: 'active', type: 'bool', isKey: false, list:true   },
        };
		return this.mergeInfoFields(defaultInfosFields, moreInfosFields, orderByMore);
    }

}
