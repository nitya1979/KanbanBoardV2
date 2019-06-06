import { Component, OnInit } from '@angular/core';
import { Project } from '../../modals/Project'
import { ProjectService } from '../../Services/project.service';
@Component({
  selector: 'project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css']
})
export class ProjectListComponent implements OnInit {
  projects:Project[];
  constructor(private projService:ProjectService) { }

  ngOnInit() {

    this.projService.getAll().subscribe(result =>{
      this.projects = result["Items"];
    })
  }

}
