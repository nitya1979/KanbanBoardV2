import { Component, OnInit } from '@angular/core';
import {MatTableDataSource} from '@angular/material';
import { TaskService } from '../Services/task.service';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {
  displayedColumns: string[] = ['Summary', 'Project', 'Stage'];
  dueTasks:object;
  constructor(private taskService:TaskService) { 
    
  }

  ngOnInit() {
    this.taskService.getDueTasks().subscribe(result =>{
      this.dueTasks = result;
    });

  }


}
