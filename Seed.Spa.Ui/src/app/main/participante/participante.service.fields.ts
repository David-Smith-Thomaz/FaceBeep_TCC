import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class ParticipanteServiceFields extends ServiceBase {


    constructor() {
		super()
	}

	getKey() {
		return "Participante";
	}

	getFormControls(moreFormControls? : any) {
		var formControls = Object.assign({
            apelido : new FormControl(),
            nomeCompleto : new FormControl(),
            endereco : new FormControl(),
            bairro : new FormControl(),
            Cep : new FormControl(),
            dataDenascimento : new FormControl(),
            participanteId : new FormControl(),
            usuarioId : new FormControl(),
            tipoDeParticipanteId : new FormControl(),
            numeroCasa : new FormControl(),
        },moreFormControls || {});
		return formControls;
	}

	getFormFields(moreFormControls?: any) {
		return new FormGroup(this.getFormControls(moreFormControls));
	}

	getInfosFields(moreInfosFields? : any, orderByMore = false) {
		var defaultInfosFields = {
                    apelido: { label: 'apelido', type: 'string', isKey: false, list:true   },
                    nomeCompleto: { label: 'nomeCompleto', type: 'string', isKey: false, list:true   },
                    endereco: { label: 'endereco', type: 'string', isKey: false, list:true   },
                    bairro: { label: 'bairro', type: 'string', isKey: false, list:true   },
                    Cep: { label: 'Cep', type: 'string', isKey: false, list:true   },
                    dataDenascimento: { label: 'dataDenascimento', type: 'DateTime', isKey: false, list:true   },
                    participanteId: { label: 'participanteId', type: 'int', isKey: true, list:false   },
                    usuarioId: { label: 'usuarioId', type: 'int', isKey: false, list:true   },
                    tipoDeParticipanteId: { label: 'tipoDeParticipanteId', type: 'int', isKey: false, list:true   },
                    numeroCasa: { label: 'numeroCasa', type: 'int', isKey: false, list:true   },
        };
		return this.mergeInfoFields(defaultInfosFields, moreInfosFields, orderByMore);
    }

}
