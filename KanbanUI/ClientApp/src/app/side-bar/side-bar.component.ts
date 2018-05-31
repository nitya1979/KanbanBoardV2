import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../Services/project.service';
import {AuthenticationService} from '../Services/authentication.service'

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css']
})
export class SideBarComponent implements OnInit {

  projects:any;
  userEmail: string;

  show:boolean = true;

  constructor(private projectService: ProjectService, private authService: AuthenticationService) { 


  }

  ngOnInit() {

    this.projects = this.projectService.getAll();
    
    this.userEmail = this.authService.email;


  }

}
