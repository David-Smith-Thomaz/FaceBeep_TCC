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
            StatusDoUsuario: { label: 'StatusDoUsuario' },
      Usuario: { label: 'Usuario' },
      TipoDeUsuario: { label: 'TipoDeUsuario' },
      Participante: { label: 'Participante' },
      TipoDeParticipante: { label: 'TipoDeParticipante' },
      Turma: { label: 'Turma' },
      StatusDaTurma: { label: 'StatusDaTurma' },
      TurmaParticipante: { label: 'TurmaParticipante' },
    };
  }

}
