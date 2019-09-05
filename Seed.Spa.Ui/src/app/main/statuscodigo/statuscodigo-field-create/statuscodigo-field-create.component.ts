import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { StatusCodigoService } from '../statuscodigo.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-statuscodigo-field-create',
    templateUrl: './statuscodigo-field-create.component.html',
    styleUrls: ['./statuscodigo-field-create.component.css']
})
export class StatusCodigoFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

   constructor(private statusCodigoService: StatusCodigoService, private ref: ChangeDetectorRef) { }

   ngOnInit() {}


    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

   


}
