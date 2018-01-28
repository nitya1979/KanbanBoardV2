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

   this.projects = this.projectSvc.getAll();
  }

}
