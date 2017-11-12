import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AccountRoutingModule} from './account-routing.module';
import {RegisterComponent} from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent} from './profile/profile.component';
import { ChangePasswordComponent}  from './change-password/change-password.component';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    AccountRoutingModule
  ],

  declarations: [
    RegisterComponent,
    LoginComponent,
    ProfileComponent,
    ChangePasswordComponent
  ],

  exports: [
    RegisterComponent,
    LoginComponent,
    ProfileComponent
  ]
 
})
export class AccountModule { }
