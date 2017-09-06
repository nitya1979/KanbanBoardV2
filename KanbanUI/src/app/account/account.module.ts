import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountRoutingModule} from './account-routing.module';
import {RegisterComponent} from './register/register.component';


@NgModule({
  imports: [
    CommonModule,
    AccountRoutingModule
  ],

  declarations: [
    RegisterComponent
  ],

  exports: [
    RegisterComponent
  ]
 
})
export class AccountModule { }
