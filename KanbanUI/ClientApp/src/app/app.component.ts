import { Component } from '@angular/core';
import { AuthenticationService} from './Services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  authenticationService:AuthenticationService;
  title = 'KanbanBoard';

  constructor(private authService : AuthenticationService)
  {
    this.authenticationService = authService;
  }
}
