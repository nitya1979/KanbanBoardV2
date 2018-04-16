import { Component, OnInit } from '@angular/core';
import {Project} from '../../modals/Project';
import {FormControl, FormGroup, Validators,FormBuilder} from '@angular/forms';
import {MatDatepickerInputEvent} from '@angular/material/datepicker';


@Component({
  selector: 'project-detail',
  templateUrl: './project-detail.component.html',
  styleUrls: ['./project-detail.component.css']
})
export class ProjectDetailComponent implements OnInit {
  projectForm:FormGroup ;
  project:Project;
  dueMin:Date;

  constructor() { }
  
  ngOnInit() {

    this.project = new Project( {ID: 1,
       Name : "First Project", 
    Description:"Project description",
      StartDate: new Date()});

    this.projectForm = new FormGroup({
        name : new FormControl(this.project.Name, Validators.required),
        description: new FormControl(this.project.Description),
        startDate: new FormControl(this.project.StartDate, [
          Validators.required
        ]),
        dueDate : new FormControl(this.project.EndDate, Validators.required)
    }) ;

    this.dueMin = new Date();
  }

  addEvent(type: string, event: MatDatepickerInputEvent<Date>) {
     this.dueMin =new Date( event.value);
  }

}
