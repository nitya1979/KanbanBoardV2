import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes} from '@angular/router';

import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent} from './home/home.component';
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
        component : HomeComponent,
        children :[
            {
                path : '',
                component : ProfileComponent,
            },
            {
                path : 'changepassword',
                component : ChangePasswordComponent
            }
        ]
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
