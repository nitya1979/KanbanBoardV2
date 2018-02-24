import { Injectable } from '@angular/core';

@Injectable()
export class AuthenticationService {

  isAuthenticated:boolean;

  constructor() {
    this.isAuthenticated = false;
   }

}
