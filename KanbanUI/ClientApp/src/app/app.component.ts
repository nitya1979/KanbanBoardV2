import { MediaMatcher } from '@angular/cdk/layout';
import { Component, ChangeDetectorRef, OnInit } from '@angular/core';
import { AuthenticationService} from './Services/authentication.service';
import { Router, RouterLink } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'KanbanBoard';
  mobileQuery: MediaQueryList;
  userEmail: string = "";

  private _mobileQueryListener: () => void;

  constructor( private authService : AuthenticationService, changeDetectorRef: ChangeDetectorRef, media: MediaMatcher, private router: Router)
  {
    this.mobileQuery = media.matchMedia('(max-width: 900px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);

  }

  Logout()
  {
    this.authService.Logout();
    this.router.navigate(['/account/login']);
  }
  ngOnInit(){
    this.userEmail = this.authService.email;

  }
  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);

  }

  get IsAuthenticated(){
    return this.authService.isAuthenticated;
  }
}
