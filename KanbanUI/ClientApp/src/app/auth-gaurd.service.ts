import { Injectable } from '@angular/core';
import { Router, CanActivate, CanDeactivate } from '@angular/router';


@Injectable()
export class AuthGaurdService implements CanActivate {

  // canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | Observable<boolean> | Promise<boolean> {
  
  // }
  constructor(private router: Router) { }
  
  canActivate(){
    if(localStorage.getItem("access_token")){
      let expiresOn = new Date(localStorage.getItem("expires_on"));
      let dateNow = new Date();
      if( expiresOn >= dateNow)
       return true;
    }

    console.log("Test");
    this.router.navigate(['/account/login']);
    return false;
  }

}

