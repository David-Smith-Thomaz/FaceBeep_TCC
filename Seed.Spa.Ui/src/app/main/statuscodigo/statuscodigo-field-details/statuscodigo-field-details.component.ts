
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-statuscodigo-field-details',
    templateUrl: './statuscodigo-field-details.component.html',
    styleUrls: ['./statuscodigo-field-details.component.css']
})
export class StatusCodigoFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
