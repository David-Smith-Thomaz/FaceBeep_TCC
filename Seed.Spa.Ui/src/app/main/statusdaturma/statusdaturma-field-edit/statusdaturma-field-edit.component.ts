import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { StatusDaTurmaService } from '../statusdaturma.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-statusdaturma-field-edit',
    templateUrl: './statusdaturma-field-edit.component.html',
    styleUrls: ['./statusdaturma-field-edit.component.css']
})
export class StatusDaTurmaFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


    constructor(private statusDaTurmaService: StatusDaTurmaService, private ref: ChangeDetectorRef) { }

    ngOnInit() {}

    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

        

   
}
