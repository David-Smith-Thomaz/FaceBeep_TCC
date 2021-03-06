﻿import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './main/main.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './common/services/auth.guard';

const APP_ROUTES_DEFAULT: Routes = [

    {
        path: '', component: MainComponent, data : { title : "Main" }, children: [

            { path: 'statuscodigo',  canActivate: [AuthGuard], loadChildren: './main/statuscodigo/statuscodigo.module#StatusCodigoModule' },

            { path: 'codigoverificacao',  canActivate: [AuthGuard], loadChildren: './main/codigoverificacao/codigoverificacao.module#CodigoVerificacaoModule' },

            { path: 'statusdousuario',  canActivate: [AuthGuard], loadChildren: './main/statusdousuario/statusdousuario.module#StatusDoUsuarioModule' },

            { path: 'usuario',  canActivate: [AuthGuard], loadChildren: './main/usuario/usuario.module#UsuarioModule' },

            { path: 'tipodeusuario',  canActivate: [AuthGuard], loadChildren: './main/tipodeusuario/tipodeusuario.module#TipoDeUsuarioModule' },

            { path: 'participante',  canActivate: [AuthGuard], loadChildren: './main/participante/participante.module#ParticipanteModule' },

            { path: 'tipodeparticipante',  canActivate: [AuthGuard], loadChildren: './main/tipodeparticipante/tipodeparticipante.module#TipoDeParticipanteModule' },

            { path: 'turma',  canActivate: [AuthGuard], loadChildren: './main/turma/turma.module#TurmaModule' },

            { path: 'statusdaturma',  canActivate: [AuthGuard], loadChildren: './main/statusdaturma/statusdaturma.module#StatusDaTurmaModule' },

            { path: 'turmaparticipante',  canActivate: [AuthGuard], loadChildren: './main/turmaparticipante/turmaparticipante.module#TurmaParticipanteModule' },

            { path: 'fotodoparticipante',  canActivate: [AuthGuard], loadChildren: './main/fotodoparticipante/fotodoparticipante.module#FotoDoParticipanteModule' },

            { path: 'dashboard',  canActivate: [AuthGuard], loadChildren: './main/dashboard/dashboard.module#DashBoardModule' }

            ]
    },

    { path: 'statuscodigo/print/:id', canActivate: [AuthGuard], loadChildren: './main/statuscodigo/statuscodigo-print/statuscodigo-print.module#StatusCodigoPrintModule' },

    { path: 'codigoverificacao/print/:id', canActivate: [AuthGuard], loadChildren: './main/codigoverificacao/codigoverificacao-print/codigoverificacao-print.module#CodigoVerificacaoPrintModule' },

    { path: 'statusdousuario/print/:id', canActivate: [AuthGuard], loadChildren: './main/statusdousuario/statusdousuario-print/statusdousuario-print.module#StatusDoUsuarioPrintModule' },

    { path: 'usuario/print/:id', canActivate: [AuthGuard], loadChildren: './main/usuario/usuario-print/usuario-print.module#UsuarioPrintModule' },

    { path: 'tipodeusuario/print/:id', canActivate: [AuthGuard], loadChildren: './main/tipodeusuario/tipodeusuario-print/tipodeusuario-print.module#TipoDeUsuarioPrintModule' },

    { path: 'participante/print/:id', canActivate: [AuthGuard], loadChildren: './main/participante/participante-print/participante-print.module#ParticipantePrintModule' },

    { path: 'tipodeparticipante/print/:id', canActivate: [AuthGuard], loadChildren: './main/tipodeparticipante/tipodeparticipante-print/tipodeparticipante-print.module#TipoDeParticipantePrintModule' },

    { path: 'turma/print/:id', canActivate: [AuthGuard], loadChildren: './main/turma/turma-print/turma-print.module#TurmaPrintModule' },

    { path: 'statusdaturma/print/:id', canActivate: [AuthGuard], loadChildren: './main/statusdaturma/statusdaturma-print/statusdaturma-print.module#StatusDaTurmaPrintModule' },

    { path: 'turmaparticipante/print/:id', canActivate: [AuthGuard], loadChildren: './main/turmaparticipante/turmaparticipante-print/turmaparticipante-print.module#TurmaParticipantePrintModule' },

    { path: 'fotodoparticipante/print/:id', canActivate: [AuthGuard], loadChildren: './main/fotodoparticipante/fotodoparticipante-print/fotodoparticipante-print.module#FotoDoParticipantePrintModule' },


]


export const RoutingDefault: ModuleWithProviders = RouterModule.forRoot(APP_ROUTES_DEFAULT);


