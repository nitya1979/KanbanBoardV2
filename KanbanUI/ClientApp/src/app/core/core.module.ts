import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AlertComponent } from './alert/alert.component';
import {MatButtonModule, MatDialogModule} from '@angular/material';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
import { CanComponentDeactivate } from './Services/CanComponentDeactivate';

@NgModule({
  imports: [
    CommonModule,
    MatButtonModule,
    MatDialogModule
  ],
  declarations: [
    AlertComponent,
    ConfirmDialogComponent
  ],

  providers:[CanComponentDeactivate],

  exports:[
    AlertComponent,
    ConfirmDialogComponent
  ],
  entryComponents:[ ConfirmDialogComponent]
})
export class CoreModule { }
