import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import {Project, ProjectStage} from '../modals/Project';
import { KanbanService } from './kanban.service';
import { environment } from '../../environments/environment';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable()
export class ProjectService extends KanbanService {

  constructor(private http: HttpClient) {
        super();
   }

  getAll(){
    return this.http.get( environment.apiBase + "projects").pipe(catchError(this.handleError));
  }

  getQuadrants(){
    return this.http.get(environment.apiBase + "projects/quadrants").pipe(catchError(this.handleError));
  }
  
  getProjectStages(projectId:number){
    return this.http.get<ProjectStage>(environment.apiBase + "projects/"+projectId+"/stages")
                    .pipe( catchError(this.handleError));
  }

  getImportant(count:number){
    return this.http.get( environment.apiBase + "projects/important/"+count).pipe(catchError(this.handleError));
  }
  get(projectId:number){
    return this.http.get(environment.apiBase + "projects/"+projectId).pipe( catchError(this.handleError));
  }

  search(name:string){
    return this.http.get<Project>( environment.apiBase+ "projects/search/"+name).pipe( catchError(this.handleError));
  }
  save(project:Project):Observable<any>{

    return this.http.post( environment.apiBase + "projects", project).pipe(
        catchError(this.handleError)
        );
    
      
  }
}