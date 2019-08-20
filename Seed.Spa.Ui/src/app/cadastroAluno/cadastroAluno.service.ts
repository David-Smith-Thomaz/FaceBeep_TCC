//EXT
import { Injectable } from '@angular/core';
import { Observable, Observer } from 'rxjs';
import { Subject } from 'rxjs';
import { FormGroup, FormControl } from '@angular/forms';
import { ServiceBase } from '../common/services/service.base';
import { ApiService } from '../common/services/api.service';
import { ViewModel } from '../common/model/viewmodel';
import { GlobalServiceCulture } from '../global.service.culture';
import { MainService } from '../main/main.service';
import { GlobalService } from '../global.service';
import { CadastroAlunoServiceFields } from './cadastroAluno.service.fields';

@Injectable()
export class CadastroAlunoService extends ServiceBase {

    private _form : FormGroup;

  constructor(private api: ApiService<any>, private serviceFields: CadastroAlunoServiceFields, private globalServiceCulture: GlobalServiceCulture, private mainService: MainService) {

        super();
        this._form = this.serviceFields.getFormFields();

    }

    initVM(): ViewModel<any> {

        return new ViewModel({
            mostrarFiltros: false,
            actionTitle: "TipoDeParticipante",
            actionDescription: "",
            key : this.serviceFields.getKey(),
            downloadUri: GlobalService.getEndPoints().DOWNLOAD,
            filterResult: [],
            modelFilter: {},
            summary: {},
            model: {},
            details: {},
            infos: this.getInfos(),
            grid: this.getInfoGrid(this.getInfos()),
            generalInfo: this.mainService.getInfos(),
            form: this._form,
            masks: this.masksConfig(),
            manterTelaAberta : false,
            navigationModal: true
        });
    }

    getInfos() {
        return this.serviceFields.getInfosFields();
    }
}
