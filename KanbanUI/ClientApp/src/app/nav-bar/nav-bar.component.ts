import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../Services/authentication.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  email: string;
  constructor(private authService: AuthenticationService) { }

  ngOnInit() {
    this.email = this.authService.email;
  }

}
