import { Injectable, Injector } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import {catchError}  from 'rxjs/operators';

import { error } from 'selenium-webdriver';
import { AuthenticationService } from './Services/authentication.service';

@Injectable()
export class KanbanHttpInterceptor implements HttpInterceptor {

    constructor(private authService: AuthenticationService){}
    
    intercept(req: HttpRequest<object>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        console.log("intercepted request ... ");
        var token =  this.authService.accessToken;
        // Clone the request to add the new header.
        if( token)
        {
        const authReq = req.clone({ headers: req.headers.set("Authorization", "Bearer "+token)});
        
        console.log("Sending request with new header now ...");

        //send the newly created request
        return next.handle(authReq).pipe(
                        catchError((error, caught) => {
                            //intercept the respons error and displace it to the console
                            console.log("Error Occurred");
                            console.log(error);
        
                            //return the error to the method that called it
                            return Observable.throw(error);
                        }) 
                        )
        }
        else{
            return next.handle(req).pipe(
                            catchError((error, caught) => {
                                console.log("Error Occured without Auth");
                                console.log(error);

                                return Observable.throw(error);
                            }) 
                        )
        }
}
}
