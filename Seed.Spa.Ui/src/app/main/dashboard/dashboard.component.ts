import { Component, OnInit, ViewChild, Output, EventEmitter, ChangeDetectorRef, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule, FormGroup, FormControl } from '@angular/forms';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../common/model/viewmodel';
import { GlobalService, NotificationParameters } from '../../global.service';
import { ComponentBase } from '../../common/components/component.base';
import { LocationHistoryService } from '../../common/services/location.history';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashBoardComponent implements OnInit {

  vm: ViewModel<any>;

  operationConfimationYes: any;
  changeCultureEmitter: EventEmitter<string>;

  ngOnInit() {

  }
}
