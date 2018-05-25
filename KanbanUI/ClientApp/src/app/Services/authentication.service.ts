import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {environment} from '../../environments/environment';

@Injectable()
export class AuthenticationService {


  constructor(private http: HttpClient) {
   }

    Login(userName, password){
     userName = 'nityaprakash';
     password = 'e58@t4Ie';
     console.log( userName + " "+ password);
        const options = 
    { params: new HttpParams().set('UserName', userName)
                                            .set('password', password)};
      console.log(environment.apiBase + "token");
     this.http.get( environment.apiBase+ "token", options).subscribe(
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