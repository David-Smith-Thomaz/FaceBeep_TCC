import { Component, OnInit, ViewChild, Output, EventEmitter, ChangeDetectorRef, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule, FormGroup, FormControl } from '@angular/forms';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../common/model/viewmodel';
import { CadastroAlunoService } from './cadastroAluno.service';
import { ApiService } from '../common/services/api.service';
import { ComponentBase } from '../common/components/component.base';
import { WebcamInitError, WebcamImage, WebcamUtil } from 'ngx-webcam';
import { Subject, Observable } from 'rxjs';

@Component({
  selector: 'app-cadastroAluno',
  templateUrl: './cadastroAluno.component.html',
  styleUrls: ['./cadastroAluno.component.css'],
})
export class CadastroAlunoComponent extends ComponentBase implements OnInit {

  vm: ViewModel<any>;
  operationConfimationYes: any;
  changeCultureEmitter: EventEmitter<string>;

  choseTypeUser: boolean;
  validationPreStepAluno: boolean;
  validationPreStepProfessor: boolean;
  step1: boolean;
  step2: boolean;
  step3: boolean;
  messageFinalyRegister: boolean;
  showWebcam = true;
  allowCameraSwitch = true;
  multipleWebcamsAvailable = false;
  deviceId: string;
  videoOptions: MediaTrackConstraints = {
    //width: {ideal: 1024},
    //height: {ideal: 576}
  };
  public errors: WebcamInitError[] = [];

  // latest snapshot
  public webcamImage: WebcamImage = null;

  // webcam snapshot trigger
  private trigger: Subject<void> = new Subject<void>();
  // switch to next / previous / specific webcam; true/false: forward/backwards, string: deviceId
  private nextWebcam: Subject<boolean | string> = new Subject<boolean | string>();

  constructor(private cadastroAlunoService: CadastroAlunoService, private router: Router, private ref: ChangeDetectorRef) {
    super();
    this.vm = null;

    this.choseTypeUser = true
    this.validationPreStepAluno = false
    this.validationPreStepProfessor = false
    this.step1 = false
    this.step2 = false
    this.step3 = false
    this.messageFinalyRegister = false
  }

  ngOnInit() {
    this.vm = this.cadastroAlunoService.initVM();
    WebcamUtil.getAvailableVideoInputs()
      .then((mediaDevices: MediaDeviceInfo[]) => {
        this.multipleWebcamsAvailable = mediaDevices && mediaDevices.length > 1;
      });
  }

  finishRegister() {
    this.messageFinalyRegister = true
    this.step1 = false
    this.step2 = false
    this.step3 = false
    this.validationPreStepAluno = false
    this.router.navigate(["/login"]);
  }

  nextRegisterChoseTypeUser(tipoUsuario: any) {

    if (tipoUsuario == 1) //TIPO ALUNO
    {
      this.choseTypeUser = false
      this.validationPreStepAluno = true
    }

    if (tipoUsuario == 2) //TIPO PROFESSOR
    {
      this.choseTypeUser = false
      this.validationPreStepProfessor = true
    }
  }

  nextRegisterStepValidationPreStep(tipoUsuario: any) {

    if (tipoUsuario == 1)
    {
      this.step1 = true
      this.validationPreStepAluno = false
    }

    if (tipoUsuario == 2) {
      this.step1 = true
      this.validationPreStepProfessor = false
    }
  }

  nextRegisterStep1() {
    this.step2 = true
    this.step1 = false
    this.step3 = false
    this.validationPreStepAluno = false
  }
  nextRegisterStep2() {
    this.step3 = true
    this.step1 = false
    this.step2 = false
    this.validationPreStepAluno = false
  }
  nextRegisterStep3() {
    this.step1 = false
    this.step2 = false
    this.step3 = false
    this.validationPreStepAluno = true
  }

  public triggerSnapshot(): void {
    this.trigger.next();
    this.showWebcam = false;
  }

  public toggleWebcam(): void {
    this.showWebcam = !this.showWebcam;
  }

  public handleInitError(error: WebcamInitError): void {
    this.errors.push(error);
  }

  public showNextWebcam(directionOrDeviceId: boolean | string): void {
    // true => move forward through devices
    // false => move backwards through devices
    // string => move to device with given deviceId
    this.nextWebcam.next(directionOrDeviceId);
  }

  public handleImage(webcamImage: WebcamImage): void {
    console.info('received webcam image', webcamImage);
    this.webcamImage = webcamImage;
  }

  public cameraWasSwitched(deviceId: string): void {
    this.deviceId = deviceId;
  }

  public triggerSnapshotAgain() {
    this.showWebcam = true;
    this.webcamImage = null
  }

  public get triggerObservable(): Observable<void> {
    return this.trigger.asObservable();
  }

  public get nextWebcamObservable(): Observable<boolean | string> {
    return this.nextWebcam.asObservable();
  }
}
