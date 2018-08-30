import { Component, OnInit } from '@angular/core';
import{ FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AccountService } from '../../Services/account.service';
import {UserDetail} from '../../modals/User';
import {DnpResult} from '../../core/model/ActionResult';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  profileForm:FormGroup;
  result:DnpResult;
  userDetail: UserDetail;
  constructor(private fb:FormBuilder, private accountService:AccountService) { }

  ngOnInit() {
    this.createForm(); 
    this.accountService.getUserDetail('nityaprakash').subscribe(data=>{
      this.userDetail = data;    
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

  reset(){
    this.setModel();
  }

  update(){

    this.userDetail.PhoneNo = this.phoneCtrl.value;

    this.accountService.updateProfile(this.userDetail).subscribe(result =>{
      this.result = new DnpResult({
        Success : true,
        Messages : ["Profile updated successfully"]
      });
    }, error =>{  
      console.log(JSON.stringify(error));
      
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
