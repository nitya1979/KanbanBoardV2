import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

export interface ConfirmDialogData {
  message:string;
  success:boolean;
}
;
@Component({
  selector: 'app-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrls: ['./confirm-dialog.component.css']
})
export class ConfirmDialogComponent implements OnInit {

  constructor( public dialogRef : MatDialogRef<ConfirmDialogComponent>, @Inject(MAT_DIALOG_DATA) public data:ConfirmDialogData) { }

  ngOnInit() {
  }

  closeDialog(){
    this.dialogRef.close(this.data.success);
  }
}
