import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes} from '@angular/router';

import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent, CanProfileDeactivate} from './profile/profile.component';
import { ChangePasswordComponent}  from './change-password/change-password.component';
import {AuthGaurdService} from '../auth-gaurd.service';
const userRoutes: Routes = [
    {
        path : 'register',
        component : RegisterComponent
    },
    {
        path : 'login',
        component : LoginComponent
    },
    {
        path : 'profile',
        component : ProfileComponent,
        canActivate : [AuthGaurdService],
        canDeactivate : [CanProfileDeactivate]
    },
    {
        path : 'changepassword',
        component: ChangePasswordComponent,
        canActivate : [AuthGaurdService]
    },
    {
        path: '',
        redirectTo: 'profile', pathMatch: 'full'
    }
];

@NgModule({
  imports: [
    RouterModule.forChild(userRoutes)
  ],
  declarations: [],

  exports: [
    RouterModule
  ]
})
export class AccountRoutingModule { }
