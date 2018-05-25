import { MediaMatcher } from '@angular/cdk/layout';
import { Component, ChangeDetectorRef } from '@angular/core';
import { AuthenticationService} from './Services/authentication.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  authenticationService:AuthenticationService;
  title = 'KanbanBoard';
  mobileQuery: MediaQueryList;

  private _mobileQueryListener: () => void;

  constructor( private authService : AuthenticationService, changeDetectorRef: ChangeDetectorRef, media: MediaMatcher)
  {
    this.mobileQuery = media.matchMedia('(max-width: 900px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
    this.authenticationService = authService;
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

}
