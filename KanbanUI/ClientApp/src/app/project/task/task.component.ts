import { Component, OnInit } from '@angular/core';
import { ISavable } from '../../core/model/ISavable';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ProjectTask, ProjectStage, Priority,Project } from '../../modals/Project';
import { ProjectService } from '../../Services/project.service';
import { ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material';
import { formArrayNameProvider } from '@angular/forms/src/directives/reactive_directives/form_group_name';
import { TaskService } from '../../Services/task.service';
import { DnpResult } from '../../core/model/ActionResult';
import { debounceTime, switchMap } from 'rxjs/operators';
import { Observable} from 'rxjs';
import {ConfirmDialogComponent} from '../../core/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit, ISavable {
  taskForm : FormGroup;
  task : ProjectTask;
  dueMin: Date;
  taskId : number = 0;
  stages : ProjectStage;
  result:DnpResult;
  priorities: any;
  filteredProject: Observable<Project>;

  constructor(private projectService:ProjectService,
              private taskService: TaskService,
              private activateRoute : ActivatedRoute,
              public dialog:MatDialog) {

                this.activateRoute.params.subscribe(param=>{
                  if(param.taskID )
                    this.taskId = param.taskID;
                  else
                    this.taskId = 0;
                });
               }

  ngOnInit() {
    this.task = new ProjectTask();
    //this.task.Project = new Project();
    //this.task.TaskPriority = new Priority();
    //this.task.Stage = new ProjectStage();
    this.createTaskForm();
    this.loadTaskPriorities();

    this.filteredProject = this.taskForm.get('project').valueChanges
                              .pipe(
                                debounceTime(300),
                                switchMap(value => this.projectService.search(value)
                              ));
  }

  isModified(){

    if( this.task.Summary != this.taskForm.controls['summary'].value ||
        this.task.Description != this.taskForm.controls['description'].value ||
        this.task.DueDate != this.taskForm.controls['dueDate'].value ||
        this.task.PriorityID != this.taskForm.controls['priority'].value ||
        this.task.StageID != this.taskForm.controls['stage'].value){

          var dialogRef = this.dialog.open( ConfirmDialogComponent, {data :{ message : "There are unsaved changes. Do you want to save?"}});
      dialogRef.afterClosed().subscribe( result =>{
        console.log( result);
        if( result)
        {
          console.log( "TRUE:"+ result);
            this.save();
        }
        
        if( result == false)
        {

          console.log("FALSE:"+result);
          this.taskForm.patchValue({
            name : this.task.Summary,
            description : this.task.Description,
            dueDate : this.task.DueDate,
            priority : this.task.PriorityID,
            stage : this.task.StageID
           });
           return true;
        }

      });
      return false;
      }
      return true;
  }

  validate(){
    return true;
  }
  save(){

    if( this.taskForm.valid){
      this.task.Summary = this.taskForm.controls['summary'].value;
      this.task.Description = this.taskForm.controls['description'].value;
      this.task.PriorityID = this.taskForm.controls['priority'].value;
      this.task.StageID = this.taskForm.controls['stage'].value;
      this.task.DueDate = this.taskForm.controls['dueDate'].value;

      this.taskService.save(this.task).subscribe( result =>{
        this.result = new DnpResult({
          Success : true,
          Messages : ["Project saved successfully"]
        });
      }, error =>{
        this.result = new DnpResult({
          Success : false,
          Messages : []
        });
        error.forEach(element => {
          this.result.Messages.push(element);
        });
      })
    }
  }

  loadStages(){
    
    var projId = this.taskForm.get('project').value.ProjectID;
    if( projId > 0){
      
      this.projectService.getProjectStages( projId ).subscribe(result =>{
        this.stages = result;
      });

    }
  }
  loadTaskPriorities(){
    this.taskService.getTaskPriorities().subscribe(result =>{
      this.priorities = result;
    });
  }
  createTaskForm(){
    this.taskForm = new FormGroup({
      summary : new FormControl(this.task.Summary, Validators.required),
      description : new FormControl(this.task.Description),
      project : new FormControl("", Validators.required),
      priority: new FormControl(this.task.PriorityID, Validators.required),
      stage : new FormControl(this.task.StageID, Validators.required ),
      dueDate: new FormControl(this.task.DueDate, Validators.required)
    });
  }
  displayFn(pj: Project) {
    if (pj) { return pj.ProjectName; }
  }
  
}
