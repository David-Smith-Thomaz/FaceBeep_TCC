
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-statusdaturma-field-details',
    templateUrl: './statusdaturma-field-details.component.html',
    styleUrls: ['./statusdaturma-field-details.component.css']
})
export class StatusDaTurmaFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
