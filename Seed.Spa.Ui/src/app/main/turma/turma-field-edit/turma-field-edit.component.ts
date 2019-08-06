import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { TurmaService } from '../turma.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-turma-field-edit',
    templateUrl: './turma-field-edit.component.html',
    styleUrls: ['./turma-field-edit.component.css']
})
export class TurmaFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


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
