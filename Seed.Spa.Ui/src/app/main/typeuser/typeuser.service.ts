﻿//EXT
import { Injectable } from '@angular/core';
import { Observable, Observer } from 'rxjs';
import { Subject } from 'rxjs';
import { FormGroup, FormControl } from '@angular/forms';

import { ApiService } from '../../common/services/api.service';
import { ServiceBase } from '../../common/services/service.base';
import { ViewModel } from '../../common/model/viewmodel';
import { GlobalService } from '../../global.service';
import { TypeUserServiceFields } from './typeuser.service.fields';
import { GlobalServiceCulture, Translated, TranslatedField } from '../../global.service.culture';
import { MainService } from '../main.service';

@Injectable()
export class TypeUserService extends ServiceBase {

    private _form : FormGroup;

    constructor(private api: ApiService<any>,private serviceFields: TypeUserServiceFields, private globalServiceCulture: GlobalServiceCulture, private mainService: MainService) {

        super();
        this._form = this.serviceFields.getFormFields();

    }

    initVM(): ViewModel<any> {

        return new ViewModel({
            mostrarFiltros: false,
            actionTitle: "TypeUser",
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

    getInfoGrid(infos : any) {
        return super.getInfoGrid(infos)
    }

    updateCulture(culture: string = null) {
        return this.getInfosTranslated(this.globalServiceCulture.defineCulture(culture));
    }

    updateCultureMain(culture: string = null) {
        return this.mainService.getInfosTranslated(this.globalServiceCulture.defineCulture(culture));
    }

    getInfosTranslated(culture: string) {
        return this.globalServiceCulture.getInfosTranslatedStrategy('TypeUser', culture, this.getInfos(), []);
    }

    get(filters?: any): Observable<any> {
        return this.api.setResource('TypeUser').get(filters);
    }

    getDataCustom(filters?: any): Observable<any> {
        return this.api.setResource('TypeUser').getDataCustom(filters);
    }

    getDataListCustom(filters?: any): Observable<any> {
        return this.api.setResource('TypeUser').getDataListCustom(filters);
    }

    save(model: any): Observable<any> {

        if (model.typeUserId) {
            return this.api.setResource('TypeUser').put(model);
        }

        return this.api.setResource('TypeUser').post(model);
    }

    delete(model: any): Observable<any> {
        return this.api.setResource('TypeUser').delete(model);
    }
    
    export(filters?: any): Observable<any> {
        return this.api.setResource('TypeUser').export(filters);
    }
}
