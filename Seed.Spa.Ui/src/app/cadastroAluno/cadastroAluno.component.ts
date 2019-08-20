import { Component, OnInit, ViewChild, Output, EventEmitter, ChangeDetectorRef, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule, FormGroup, FormControl } from '@angular/forms';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../common/model/viewmodel';

@Component({
  selector: 'app-cadastroAluno',
  templateUrl: './cadastroAluno.component.html',
  styleUrls: ['./cadastroAluno.component.css'],
})
export class CadastroAlunoComponent implements OnInit {

  vm: ViewModel<any>;

  operationConfimationYes: any;
  changeCultureEmitter: EventEmitter<string>;

  ngOnInit() {

  }
}
