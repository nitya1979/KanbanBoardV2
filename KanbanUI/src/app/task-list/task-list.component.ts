import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {
  tasks:any;
  columns:any =[
    {caption : "Task Summary", name:"Summary"},
    {caption : "Project", name:"Project"},
    {caption : "Due Date", name:"DueDate"}
  ]

  constructor() { }

  ngOnInit() {
    this.tasks = [
        {
            Summary: "Task 1 For Project 1",
            Project: "Project 1",
            DueDate: "09/30/2017",
        },{
            Summary: "Task 2 For Project 1",
            Project: "Project 1",
            DueDate: "09/30/2017",
        },{
            Summary: "Task 1 For Project 2",
            Project: "Project 2",
            DueDate: "09/30/2017",
        },{
            Summary: "Task 2 For Project 2",
            Project: "Project 2",
            DueDate: "09/30/2017",
        }
    ]
  }


}
