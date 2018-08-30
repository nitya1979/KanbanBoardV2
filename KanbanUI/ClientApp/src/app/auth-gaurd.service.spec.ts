import { TestBed, inject } from '@angular/core/testing';

import { AuthGaurdService } from './auth-gaurd.service';
import { RouterModule, CanActivate, Router } from '@angular/router';
import{ AppModule} from './app.module'
import { AppRoutingModule } from './app-routing.module';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';

describe('AuthGaurdService', () => {
  let service: AuthGaurdService;

  let router = {
    navigate: jasmine.createSpy('navigate')
};
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports:[RouterTestingModule],
      providers: [AuthGaurdService, {provide: Router, useValue: router}]
    }).compileComponents();
  });

  beforeEach(()=>{
    service = TestBed.get( AuthGaurdService);
  });
  it('should be created', () => {
    
    expect(service).toBeTruthy(); 
  });

  it('be able to hit route when user is logged in', () => {

    var today = new Date();
    var tomorrow = new Date();
    tomorrow.setDate(today.getDate()+1);

    localStorage.setItem("access_token", "token");
    localStorage.setItem("expires_on", tomorrow.toString());
    expect(service.canActivate()).toBe(true);
});

it('not be able to hit route when user is not logged in', () => {
    var today = new Date();
    var yest = new Date();
    yest.setDate(today.getDate()-1);
    localStorage.setItem("access_token", "token");
    localStorage.setItem("expires_on", yest.toString());
    expect(service.canActivate()).toBe(false);
});
});
