import { Component, OnInit, ViewChild, Output, EventEmitter, ChangeDetectorRef, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule, FormGroup, FormControl } from '@angular/forms';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../common/model/viewmodel';
import { CadastroAlunoService } from './cadastroAluno.service';
import { ApiService } from '../common/services/api.service';
import { ComponentBase } from '../common/components/component.base';

@Component({
  selector: 'app-cadastroAluno',
  templateUrl: './cadastroAluno.component.html',
  styleUrls: ['./cadastroAluno.component.css'],
})
export class CadastroAlunoComponent extends ComponentBase implements OnInit {

  vm: ViewModel<any>;
  operationConfimationYes: any;
  changeCultureEmitter: EventEmitter<string>;

  step1: boolean;
  step2: boolean;
  step3: boolean;

  constructor(private cadastroAlunoService: CadastroAlunoService, private router: Router, private ref: ChangeDetectorRef) {
    super();
    this.vm = null;

    this.step1 = true
    this.step2 = false
    this.step3 = false
  }

  ngOnInit() {
    this.vm = this.cadastroAlunoService.initVM();
  }

  finishRegister() {

  }

  nextRegisterStep1() {
    this.step1 = false
    this.step2 = true
    this.step3 = false
  }
  nextRegisterStep2() {
    this.step1 = false
    this.step2 = false
    this.step3 = true
  }
  nextRegisterStep3() {
    this.step1 = false
    this.step2 = false
    this.step3 = false
  }
}
