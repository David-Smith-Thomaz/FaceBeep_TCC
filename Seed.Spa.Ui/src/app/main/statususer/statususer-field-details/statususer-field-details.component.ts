
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-statususer-field-details',
    templateUrl: './statususer-field-details.component.html',
    styleUrls: ['./statususer-field-details.component.css']
})
export class StatusUserFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
