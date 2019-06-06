import { Injectable } from '@angular/core';
import { KanbanService } from './kanban.service';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { catchError } from 'rxjs/operators';
import { ProjectTask } from '../modals/Project';

@Injectable({
  providedIn: 'root'
})
export class TaskService extends KanbanService{

  constructor(private http:HttpClient) { 
    super();
  }

  
  getTaskPriorities(){
    return this.http.get(environment.apiBase + "task/priorities" ).pipe(catchError(this.handleError));
  }

  getTasks(projectId:number){
    var url = "projects/"+projectId+"/tasks";
    return this.http.get(environment.apiBase + url).pipe(catchError(this.handleError));
  }

  getDueTasks(){
    var url = "task/duetasks";
    return this.http.get(environment.apiBase + url).pipe(catchError(this.handleError));
  }

  save(task:ProjectTask){
    var url = environment.apiBase + "task";
    return this.http.post(url, task).pipe(catchError(this.handleError));
    
  }
}
