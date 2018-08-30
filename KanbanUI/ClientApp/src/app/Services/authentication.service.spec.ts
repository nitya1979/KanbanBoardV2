import { TestBed, inject } from '@angular/core/testing';

import { AuthenticationService } from './authentication.service';
import {KanbanService} from './kanban.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';

describe('AuthenticationService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports :[HttpClientModule],
      providers: [AuthenticationService]
    });
  });

  it('should be created', inject([AuthenticationService], (service: AuthenticationService) => {
    expect(service).toBeTruthy();
  }));
});
