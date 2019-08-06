import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class TurmaServiceFields extends ServiceBase {


    constructor() {
		super()
	}

	getKey() {
		return "Turma";
	}

	getFormControls(moreFormControls? : any) {
		var formControls = Object.assign({
            codigoDaTurma : new FormControl(),
            nome : new FormControl(),
            descricao : new FormControl(),
            dataInicio : new FormControl(),
            dataFim : new FormControl(),
            turmaId : new FormControl(),
            admTurmaId : new FormControl(),
            statusDaTurmaId : new FormControl(),
        },moreFormControls || {});
		return formControls;
	}

	getFormFields(moreFormControls?: any) {
		return new FormGroup(this.getFormControls(moreFormControls));
	}

	getInfosFields(moreInfosFields? : any, orderByMore = false) {
		var defaultInfosFields = {
                    codigoDaTurma: { label: 'codigoDaTurma', type: 'string', isKey: false, list:true   },
                    nome: { label: 'nome', type: 'string', isKey: false, list:true   },
                    descricao: { label: 'descricao', type: 'string', isKey: false, list:false   },
                    dataInicio: { label: 'dataInicio', type: 'DateTime', isKey: false, list:true   },
                    dataFim: { label: 'dataFim', type: 'DateTime', isKey: false, list:true   },
                    turmaId: { label: 'turmaId', type: 'int', isKey: true, list:false   },
                    admTurmaId: { label: 'admTurmaId', type: 'int', isKey: false, list:true   },
                    statusDaTurmaId: { label: 'statusDaTurmaId', type: 'int', isKey: false, list:true   },
        };
		return this.mergeInfoFields(defaultInfosFields, moreInfosFields, orderByMore);
    }

}
