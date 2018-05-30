import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators,FormBuilder} from '@angular/forms';
import {ChangePasswordModel} from '../../modals/RegisterModel';
import {AccountService} from '../../Services/account.service';
import { compareValidator} from '../../directives/compare-validadator.directive';

@Component({
  selector: 'change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})

export class ChangePasswordComponent implements OnInit {
  changePasswordForm: FormGroup;
  changePasswordModel: ChangePasswordModel;

  constructor(private fb: FormBuilder, private accountService : AccountService) { }

  ngOnInit() {
    this.createForm();
  }

  reset()
  {
    this.createForm();
  }

  createForm(){

    this.changePasswordForm = this.fb.group({
      currentPassword : ['', Validators.required],
      newPassword :['', Validators.required],
      confirmPassword : ['', [Validators.required, compareValidator('newPassword')]]
    });
  }

  getModelForSave()
  {
    this.changePasswordModel = {
      CurrentPassword : this.currentPassword.value,
      NewPassword : this.newPassword.value,
      ConfirmPassword : this.confirmPassword.value
    };
  }
  update(){
    this.getModelForSave();
    console.log( JSON.stringify( this.changePasswordModel));
    this.accountService.updatePassword(this.changePasswordModel).subscribe(
      (data)=> {alert(JSON.stringify(data));},
      (error)=> {alert(JSON.stringify(error));}
    );
  }
  get currentPassword() { return this.changePasswordForm.get('currentPassword');}
  get newPassword() { return this.changePasswordForm.get('newPassword');}
  get confirmPassword() { return this.changePasswordForm.get('confirmPassword');}
}
