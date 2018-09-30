import { Component, OnInit, Injectable } from '@angular/core';
import {Project} from '../../modals/Project';
import {FormControl, FormGroup, Validators,FormBuilder} from '@angular/forms';
import {MatDatepickerInputEvent} from '@angular/material/datepicker';
import { ProjectService } from '../../Services/project.service';
import { DnpResult } from '../../core/model/ActionResult';
import {ISavable} from '../../core/model/ISavable';
import { MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import {ConfirmDialogComponent} from '../../core/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'project-detail',
  templateUrl: './project-detail.component.html',
  styleUrls: ['./project-detail.component.css']
})
export class ProjectDetailComponent implements OnInit, ISavable {
  projectForm:FormGroup ;
  project:Project;
  dueMin:Date;
  result:DnpResult;
  projectId:number = 0;

  constructor(private projectService:ProjectService, 
              private activatedRoute:ActivatedRoute, 
              public dialog: MatDialog) { 

    this.activatedRoute.params.subscribe( params => {
      if( params.projectID)
        this.projectId = params.projectID;
      else
        this.projectId = 0;
    })
  }
  
  ngOnInit() {

      this.project = new Project();
      this.createProjectForm();

      this.projectService.get(this.projectId).subscribe(result =>{
        this.project = new Project({
          ProjectID : result.ProjectID,
          ProjectName : result.ProjectName,
          Description : result.Description,
          StartDate : result.StartDate,
          DueDate : result.DueDate
        });
        console.log(JSON.stringify(this.project));
        this.createProjectForm();
      })


    this.dueMin = new Date();
  }

  isModified(){
    
    if( this.project.ProjectName != this.projectForm.controls['name'].value ||
        this.project.Description != this.projectForm.controls['description'].value ||
        this.project.StartDate != this.projectForm.controls['startDate'].value ||
        this.project.DueDate != this.projectForm.controls['dueDate'].value )
    {
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
          this.projectForm.patchValue({
            name : this.project.ProjectName,
            description : this.project.Description,
            startDate : this.project.StartDate,
             dueDate : this.project.DueDate
           })
        }

      });
      return false;
    }
    return true;
  }
  createProjectForm(){
    this.projectForm = new FormGroup({
      name : new FormControl(this.project.ProjectName, Validators.required),
      description: new FormControl(this.project.Description),
      startDate: new FormControl(this.project.StartDate, [
        Validators.required
      ]),
      dueDate : new FormControl(this.project.DueDate, Validators.required)
  }) ;
  }
  addEvent(type: string, event: MatDatepickerInputEvent<Date>) {
     this.dueMin =new Date( event.value);
     
  }

  validate(){
    return true;
  }
  save()
  {
    if( this.projectForm.valid)
    {
        this.project.ProjectName = this.projectForm.controls['name'].value;
        this.project.Description = this.projectForm.controls['description'].value;
        this.project.StartDate = this.projectForm.controls['startDate'].value;
        this.project.DueDate = this.projectForm.controls['dueDate'].value;
      
        this.projectService.save(this.project).subscribe( result =>{
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
}

