import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import{MatCardModule,MatFormFieldModule, MatInputModule, MatDatepickerModule, MatIcon, MatButtonModule, MatCheckboxModule, MatIconModule} from '@angular/material';

import { AccountRoutingModule} from './account-routing.module';
import {RegisterComponent} from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent} from './profile/profile.component';
import { ChangePasswordComponent}  from './change-password/change-password.component';
import {CoreModule} from '../core/core.module';


@NgModule({
  imports: [
    CommonModule,
    CoreModule,
    FormsModule,
    FormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule, 
    AccountRoutingModule,
    MatButtonModule,
    MatCheckboxModule,
    ReactiveFormsModule,
    MatIconModule
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
