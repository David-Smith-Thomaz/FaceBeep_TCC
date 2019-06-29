
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-user-field-details',
    templateUrl: './user-field-details.component.html',
    styleUrls: ['./user-field-details.component.css']
})
export class UserFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
