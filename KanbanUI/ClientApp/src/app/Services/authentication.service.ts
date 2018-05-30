import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {environment} from '../../environments/environment';
import { Token } from '@angular/compiler';
import {Observable} from 'rxjs';
import {_throw } from 'rxjs/observable/throw';
import { catchError, retry } from 'rxjs/operators';
import { KanbanService } from './kanban.service';

@Injectable()
export class AuthenticationService extends KanbanService {
  private TOKEN_KEY:string = "access_token";
  private EXIPRE_ON_KEY: string = "expires_on";

  constructor(private http: HttpClient) {
     super();
   }

    Login(userName:string, password:string, remember:boolean){
     
       const options ={ params: new HttpParams().set('UserName', userName).set('password', password)};

       return this.http.get( environment.apiBase+ "token", options).map(
       res =>{ 
        
         localStorage.clear();
         sessionStorage.clear();

         if( remember == true){

            localStorage.setItem(this.TOKEN_KEY, res["access_token"]);
            localStorage.setItem(this.EXIPRE_ON_KEY, res["expires_on"]);
         }else{
            sessionStorage.setItem(this.TOKEN_KEY, res["access_token"]);
            sessionStorage.setItem(this.EXIPRE_ON_KEY, res["expires_on"]);
        }

        return  "success";
       }
     ).pipe(
       catchError(this.handleError)
     );
   }

   get accessToken() { 
    if( sessionStorage.getItem(this.TOKEN_KEY)){
      return sessionStorage.getItem(this.TOKEN_KEY);
    }else{
      return localStorage.getItem(this.TOKEN_KEY);
    }
  }

  get expiresOn() {
    if( sessionStorage.getItem(this.EXIPRE_ON_KEY)){
      return sessionStorage.getItem(this.EXIPRE_ON_KEY);
    }else{
      return localStorage.getItem(this.EXIPRE_ON_KEY);
    }
  }

  get isAuthenticated(){
    if(this.accessToken){
      let expiresOn = new Date(this.expiresOn);
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
