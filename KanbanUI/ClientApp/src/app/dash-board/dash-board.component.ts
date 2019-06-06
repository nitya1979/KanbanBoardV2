import {NgModule} from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../Services/project.service';

@Component({
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.css']
})
export class DashBoardComponent implements OnInit {

  projects:any;

  constructor(private projectSvc: ProjectService) { }

  ngOnInit() {

   this.projectSvc.getImportant(4).subscribe( result =>{
     
     this.projects = result;
   });
  }

}
