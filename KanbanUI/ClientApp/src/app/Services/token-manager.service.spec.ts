import { TestBed, inject } from '@angular/core/testing';

import { TokanenManagerService } from './tokanen-manager.service';

describe('TokanenManagerService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TokanenManagerService]
    });
  });

  it('should be created', inject([TokanenManagerService], (service: TokanenManagerService) => {
    expect(service).toBeTruthy();
  }));
});
