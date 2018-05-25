import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators,FormBuilder} from '@angular/forms';
import { AuthenticationService} from '../../Services/authentication.service';


@Component({
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
 userName:string;
 password:string;

  constructor(private authService : AuthenticationService) {
    
   }

  ngOnInit() {
  }
  
  login(){
    this.authService.Login(this.userName, this.password);
    console.log(localStorage.getItem("access_token"));
  }
}
