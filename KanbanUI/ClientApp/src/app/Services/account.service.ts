import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpErrorResponse } from '@angular/common/http';
import {RegisterModel, ChangePasswordModel} from '../modals/RegisterModel';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { KanbanService } from './kanban.service';

@Injectable()
export class AccountService extends KanbanService{

  constructor(private httpClient: HttpClient) {
      super();
   }

   register(registerModel:RegisterModel):Observable<any>{

    return this.httpClient.post( environment.apiBase + "account/register", registerModel, {})
     .pipe( 
        catchError(this.handleError)
      );
   };

   validateUser(userName:string):Observable<any>{

    return this.httpClient.get(environment.apiBase + "account/validateuser/"+ userName)
            .pipe(
              catchError(this.handleError)
            );
   }

   validateEmail(email:string):Observable<any>{

    return this.httpClient.get(environment.apiBase + "account/validateemail/"+ email)
            .pipe(
              catchError(this.handleError)
            );
   }

   updatePassword(changePasswordModel:ChangePasswordModel):Observable<any>{
     return this.httpClient.post(environment.apiBase + "account/changepassword", changePasswordModel)
                .pipe(
                  catchError(this.handleError)
                );
   }
   
   
}
