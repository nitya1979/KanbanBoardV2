import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes} from '@angular/router';

import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent} from './profile/profile.component';
import { ChangePasswordComponent}  from './change-password/change-password.component';

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
        component : ProfileComponent
    },
    {
        path : 'changepassword',
        component: ChangePasswordComponent
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
