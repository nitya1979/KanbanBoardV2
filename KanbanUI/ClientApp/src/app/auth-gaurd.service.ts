import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';


@Injectable()
export class AuthGaurdService implements CanActivate {

  // canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | Observable<boolean> | Promise<boolean> {
  
  // }
  constructor(private router: Router) { }
  
  canActivate(){
    if(localStorage.getItem("currentUser")){
     
      
      return true; 

    }

    console.log("Test");
    this.router.navigate(['/account/login']);
    return false;
  }

}
