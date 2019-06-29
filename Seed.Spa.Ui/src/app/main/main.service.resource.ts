import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ServiceBase } from '../common/services/service.base';


@Injectable()
export class MainServiceResource extends ServiceBase {


  constructor() {
    super()
  }



  getInfosResources() {
    return {
            Participant: { label: 'Participant' },
      User: { label: 'User' },
      StatusUser: { label: 'StatusUser' },
      TypeUser: { label: 'TypeUser' },
      GroupParticipant: { label: 'GroupParticipant' },
      Register: { label: 'Register' },
      StatusRegister: { label: 'StatusRegister' },
    };
  }

}
