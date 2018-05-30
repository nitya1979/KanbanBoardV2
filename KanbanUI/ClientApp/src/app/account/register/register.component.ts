import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators,FormBuilder, AbstractControl, ValidatorFn} from '@angular/forms';
import { RegisterModel } from '../../modals/RegisterModel';
import { validateConfig } from '@angular/router/src/config';
import {AccountService} from '../../Services/account.service';
import { compareValidator} from '../../directives/compare-validadator.directive';


@Component({
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {
  registerForm : FormGroup;
  registerModel : RegisterModel;
  userNameExists : boolean;
  emailExists : boolean;

  constructor(private fb: FormBuilder, private accountService : AccountService) { }

  ngOnInit() {
    this.createForm();
    
  }

  createForm(){
    this.registerForm = this.fb.group({
      userName : ['', Validators.required],
      email : ['', [Validators.required, Validators.email]],
      password :['', Validators.required],
      retypePassword : ['', [Validators.required, compareValidator('password')]]});
  }

  register(){
    this.getRegistorValue();
    this.accountService.register(this.registerModel).subscribe(
      (data:any)=> alert(JSON.stringify(data)),
      error => alert(JSON.stringify(error))
    );
    
  }

  validateUser()
  {
    console.log('validate user '+ this.userName.value);
    this.accountService.validateUser(this.userName.value)
                       .subscribe(
                         (data:any)=> {
                           console.log("success " + JSON.stringify(data));
                           this.userNameExists = false;},
                        error => {
                          this.userName.setErrors({key:'exist', value: this.userName.value + 'already taken'});
                          this.userNameExists = true;
                          console.log( "error " + JSON.stringify(error));
                       });
  }

  validateEmail()
  {
    console.log('validate email '+ this.email.value);
    this.accountService.validateEmail(this.email.value)
                       .subscribe(
                         (data:any)=> {
                          console.log("success " + JSON.stringify(data)); 
                          this.emailExists = false;},
                         error => {
                           this.email.setErrors({key:'exist', value: this.userName.value + 'already taken'});
                           this.emailExists = true;
                           console.log( "error " + JSON.stringify(error));
                       });
  }
  getRegistorValue()
  {
    this.registerModel = {
      UserName : this.userName.value,
      Email : this.email.value,
      Password : this.password.value,
      ConfirmPassword : this.retypePassword.value
    };

  }
  get userName() { return this.registerForm.get('userName');}
  get email() { return this.registerForm.get('email');}
  get password() { return this.registerForm.get('password');}
  get retypePassword() { return this.registerForm.get('retypePassword');}

}
