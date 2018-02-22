import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class KanbanSharedService {
  IsAuthenticated:any = false;
  OnAuthenticate:Observable<any> ;

  constructor() { }

  
}
