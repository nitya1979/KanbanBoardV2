import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes} from '@angular/router';

import { RegisterComponent } from './register/register.component';

const userRoutes: Routes = [
    {path : 'register',
    component : RegisterComponent
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
