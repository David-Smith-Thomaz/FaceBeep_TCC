import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { TurmaService } from '../turma.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-turma-field-create',
    templateUrl: './turma-field-create.component.html',
    styleUrls: ['./turma-field-create.component.css']
})
export class TurmaFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

   constructor(private turmaService: TurmaService, private ref: ChangeDetectorRef) { }

   ngOnInit() {}


    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

   


}
