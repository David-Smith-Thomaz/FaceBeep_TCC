import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { StatusDaTurmaService } from '../statusdaturma.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-statusdaturma-field-create',
    templateUrl: './statusdaturma-field-create.component.html',
    styleUrls: ['./statusdaturma-field-create.component.css']
})
export class StatusDaTurmaFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

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
