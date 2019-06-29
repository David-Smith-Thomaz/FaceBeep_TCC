
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-register-field-details',
    templateUrl: './register-field-details.component.html',
    styleUrls: ['./register-field-details.component.css']
})
export class RegisterFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
