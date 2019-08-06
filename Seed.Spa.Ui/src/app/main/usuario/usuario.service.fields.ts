import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class UsuarioServiceFields extends ServiceBase {


    constructor() {
		super()
	}

	getKey() {
		return "Usuario";
	}

	getFormControls(moreFormControls? : any) {
		var formControls = Object.assign({
            login : new FormControl(),
            senha : new FormControl(),
            email : new FormControl(),
            usuarioId : new FormControl(),
            statusDoUsuarioId : new FormControl(),
            tipoDeUsuarioId : new FormControl(),
            participanteId : new FormControl(),
        },moreFormControls || {});
		return formControls;
	}

	getFormFields(moreFormControls?: any) {
		return new FormGroup(this.getFormControls(moreFormControls));
	}

	getInfosFields(moreInfosFields? : any, orderByMore = false) {
		var defaultInfosFields = {
                    login: { label: 'login', type: 'string', isKey: false, list:true   },
                    senha: { label: 'senha', type: 'string', isKey: false, list:true   },
                    email: { label: 'email', type: 'string', isKey: false, list:true   },
                    usuarioId: { label: 'usuarioId', type: 'int', isKey: true, list:false   },
                    statusDoUsuarioId: { label: 'statusDoUsuarioId', type: 'int', isKey: false, list:true   },
                    tipoDeUsuarioId: { label: 'tipoDeUsuarioId', type: 'int', isKey: false, list:true   },
                    participanteId: { label: 'participanteId', type: 'int?', isKey: false, list:true   },
        };
		return this.mergeInfoFields(defaultInfosFields, moreInfosFields, orderByMore);
    }

}
