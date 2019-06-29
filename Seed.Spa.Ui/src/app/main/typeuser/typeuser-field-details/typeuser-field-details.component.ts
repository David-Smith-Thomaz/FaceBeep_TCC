
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-typeuser-field-details',
    templateUrl: './typeuser-field-details.component.html',
    styleUrls: ['./typeuser-field-details.component.css']
})
export class TypeUserFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
