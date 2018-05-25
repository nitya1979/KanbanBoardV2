import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css']
})
export class ProjectListComponent implements OnInit {
  projects:String[] = [ "Project 1", "Project 2", "Project 3", "Poject 4", "Project 5", "Project 6"] ;
  constructor() { }

  ngOnInit() {
  }

}
