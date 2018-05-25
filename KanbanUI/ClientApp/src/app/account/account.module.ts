import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import{MatCardModule,MatFormFieldModule, MatInputModule, MatDatepickerModule, MatButtonModule, MatCheckboxModule} from '@angular/material';

import { AccountRoutingModule} from './account-routing.module';
import {RegisterComponent} from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent} from './profile/profile.component';
import { ChangePasswordComponent}  from './change-password/change-password.component';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    FormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule, 
    AccountRoutingModule,
    MatButtonModule,
    MatCheckboxModule
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
    ProfileComponent,
    ChangePasswordComponent
  ]
 
})
export class AccountModule { }
