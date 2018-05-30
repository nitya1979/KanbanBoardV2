import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import {Observable} from 'rxjs';
@Injectable()
export class KanbanService {

  constructor() { }

  protected handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }

    if( error.status == 400)
    return Observable.throw(error.error);
    // return an observable with a user-facing error message
    return Observable.throw(
      'Something bad happened; please try again later.');
  };
}
