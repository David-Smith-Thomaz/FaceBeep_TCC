
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-statusregister-field-details',
    templateUrl: './statusregister-field-details.component.html',
    styleUrls: ['./statusregister-field-details.component.css']
})
export class StatusRegisterFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
