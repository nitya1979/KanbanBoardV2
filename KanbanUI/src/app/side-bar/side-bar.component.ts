import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../Services/project.service';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css']
})
export class SideBarComponent implements OnInit {

  projects:any;

  constructor(private projectService: ProjectService) { 
    this.projects = this.projectService.getAll();
  }

  ngOnInit() {
  }

}
