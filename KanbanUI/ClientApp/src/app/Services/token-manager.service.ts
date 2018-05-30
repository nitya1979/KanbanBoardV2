import { Injectable } from '@angular/core';

@Injectable()
export class TokanenManagerService {

  constructor() { }

  setToken(accessToken:string, expiresOn:string, remember:boolean)
  {
    if( remember){
      localStorage.setItem("access_token", accessToken);
      localStorage.setItem("expires_on", expiresOn);
    }
    else{
      sessionStorage.setItem("access_token", accessToken);
      sessionStorage.setItem("expires_on", expiresOn);
    }
  }

  get accessToken() { 
    if( sessionStorage.getItem("access_token")){
      return sessionStorage.getItem("access_token");
    }else{
      return localStorage.getItem("access_token");
    }
  }

  get expiresOn() {
    if( sessionStorage.getItem("expires_on")){
      return sessionStorage.getItem("expires_on");
    }else{
      return localStorage.getItem("expires_on");
    }
  }
}
