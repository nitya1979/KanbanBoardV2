import { Component, OnInit, Injectable } from '@angular/core';
import{Location} from '@angular/common';
import {CanDeactivate} from '@angular/router';

import{ FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AccountService } from '../../Services/account.service';
import {UserDetail} from '../../modals/User';
import {DnpResult} from '../../core/model/ActionResult';
import {ConfirmDialogComponent} from '../../core/confirm-dialog/confirm-dialog.component';
import { MatDialog } from '@angular/material';


@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  profileForm:FormGroup;
  result:DnpResult;
  userDetail: UserDetail;
  constructor(private fb:FormBuilder, 
              private accountService:AccountService, 
              private location:Location, 
              public dialog: MatDialog) { }

  ngOnInit() {
    this.createForm(); 
    this.accountService.getUserDetail('nityaprakash').subscribe(data=>{
      this.userDetail = data
      alert(JSON.stringify(this.userDetail));
      this.setModel();

    });
    
    //alert(this.profileForm.get('userId').value);
  }

  private setModel(){
    this.profileForm.patchValue({
      userId : this.userDetail.UserId,
      userName : this.userDetail.UserName,
      email: this.userDetail.Email,
      phoneCtrl : this.userDetail.PhoneNo
    });

  }
  createForm(){
    this.profileForm = this.fb.group({
      userId : [{value:'', disabled:true}],
      email : [{value:'', disabled:true}],
      userName: [''],
      phoneCtrl : ['']
    });
  }

  cancel(){
    if( !this.isModified()){
    var dialogRef = this.dialog.open( ConfirmDialogComponent, {data :{ message : "There are unsaved changes. Do you want to save?"}});
      dialogRef.afterClosed().subscribe( result =>{
        console.log( JSON.stringify( result));
        if( result)
        {
          console.log( "TRUE:"+ result);
            this.update();
        }
        
        if( result == false)
        {

          console.log("FALSE:"+result);
          this.setModel();
        }

      });
    }
    else {
      this.setModel();
    }
    
  }

  
  isModified(){
    if( this.userDetail.UserName != this.userName.value ||
         this.userDetail.PhoneNo != this.phoneCtrl.value){
           console.log(" modified.");
           return false;
     }
    else
      return true;
  }

  update(){

    this.userDetail.PhoneNo = this.phoneCtrl.value;

    this.accountService.updateProfile(this.userDetail).subscribe(result =>{
      this.result = new DnpResult({
        Success : true,
        Messages : ["Profile updated successfully"]
      });
    }, error =>{  
      this.result = new DnpResult({
      Success : false,
      Messages : []
    });
    error.forEach(element => {
      this.result.Messages.push(element);
    });
  }
    );
    
  }

  

  get userId() { return this.profileForm.get('userId');}
  get userName() { return this.profileForm.get('userName');}
  get email() { return this.profileForm.get('email');}
  get phoneCtrl() { return this.profileForm.get('phoneCtrl');}
}

@Injectable()
export class CanProfileDeactivate implements CanDeactivate<ProfileComponent> {

  canDeactivate(component: ProfileComponent){
    component.cancel();

    return component.isModified();
  }
}
