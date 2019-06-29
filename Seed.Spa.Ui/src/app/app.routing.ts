import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './main/main.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './common/services/auth.guard';

const APP_ROUTES_DEFAULT: Routes = [

    {
        path: '', component: MainComponent, data : { title : "Main" }, children: [

            { path: 'participant',  canActivate: [AuthGuard], loadChildren: './main/participant/participant.module#ParticipantModule' },

            { path: 'user',  canActivate: [AuthGuard], loadChildren: './main/user/user.module#UserModule' },

            { path: 'statususer',  canActivate: [AuthGuard], loadChildren: './main/statususer/statususer.module#StatusUserModule' },

            { path: 'typeuser',  canActivate: [AuthGuard], loadChildren: './main/typeuser/typeuser.module#TypeUserModule' },

            { path: 'groupparticipant',  canActivate: [AuthGuard], loadChildren: './main/groupparticipant/groupparticipant.module#GroupParticipantModule' },

            { path: 'register',  canActivate: [AuthGuard], loadChildren: './main/register/register.module#RegisterModule' },

            { path: 'statusregister',  canActivate: [AuthGuard], loadChildren: './main/statusregister/statusregister.module#StatusRegisterModule' },

            { path: 'sampledash',  canActivate: [AuthGuard], loadChildren: './main/sampledash/sampledash.module#SampleDashModule' }

            ]
    },

    { path: 'participant/print/:id', canActivate: [AuthGuard], loadChildren: './main/participant/participant-print/participant-print.module#ParticipantPrintModule' },

    { path: 'user/print/:id', canActivate: [AuthGuard], loadChildren: './main/user/user-print/user-print.module#UserPrintModule' },

    { path: 'statususer/print/:id', canActivate: [AuthGuard], loadChildren: './main/statususer/statususer-print/statususer-print.module#StatusUserPrintModule' },

    { path: 'typeuser/print/:id', canActivate: [AuthGuard], loadChildren: './main/typeuser/typeuser-print/typeuser-print.module#TypeUserPrintModule' },

    { path: 'groupparticipant/print/:id', canActivate: [AuthGuard], loadChildren: './main/groupparticipant/groupparticipant-print/groupparticipant-print.module#GroupParticipantPrintModule' },

    { path: 'register/print/:id', canActivate: [AuthGuard], loadChildren: './main/register/register-print/register-print.module#RegisterPrintModule' },

    { path: 'statusregister/print/:id', canActivate: [AuthGuard], loadChildren: './main/statusregister/statusregister-print/statusregister-print.module#StatusRegisterPrintModule' },


]


export const RoutingDefault: ModuleWithProviders = RouterModule.forRoot(APP_ROUTES_DEFAULT);


