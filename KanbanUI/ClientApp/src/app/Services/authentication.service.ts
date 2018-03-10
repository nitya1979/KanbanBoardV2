import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';


@Injectable()
export class AuthenticationService {


  constructor(private http: HttpClient) {
   }

    Login(userName, password){
     userName = 'nityaprakash';
     password = 'e58@t4Ie';
        const options = 
    { params: new HttpParams().set('UserName', userName)
                                            .set('password', password)};

     this.http.get("http://localhost:5000/api/token", options).subscribe(
       res =>{ 
         localStorage.setItem("access_token", res["access_token"]);
         localStorage.setItem("expires_on", res["expires_on"]);
        
       },
       msg => console.error(`Error: ${msg.status} ${msg.statusText}`)
       
     );
   }

   get isAuthenticated(){
     if(localStorage.getItem("access_token")){
       let expiresOn = new Date(localStorage.getItem("expires_on"));
       let dateNow = new Date();
       if( expiresOn < dateNow)
        return false;
      else
        return true;
     }
    else
      return false;
   }
}
