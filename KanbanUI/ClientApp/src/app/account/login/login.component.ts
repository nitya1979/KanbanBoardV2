import { Component, OnInit, OnChanges } from '@angular/core';
import {FormControl, FormGroup, Validators,FormBuilder} from '@angular/forms';
import { AuthenticationService} from '../../Services/authentication.service';
import { Router } from '@angular/router';


@Component({
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit, OnChanges {
 userName:string;
 password:string;
 remember:boolean = true;
 loginError: boolean = false;
 errorMessage : string;
 
  constructor(private authService : AuthenticationService,private router: Router ) {
    
   }

  ngOnInit() {
    console.log("Intialized");
  }
  
  ngOnChanges(){
    console.log("changing ");
  }
  login(){
    this.loginError = false;
    this.errorMessage = "";
    
    this.authService.Login(this.userName, this.password, this.remember).subscribe(
      respsone => {
        if( respsone == "success"){
          this.router.navigate(['/dashboard']);
        }  
      },
      error => { this.loginError = true, this.errorMessage = error;});
    //console.log(localStorage.getItem("access_token"));
  }
}
