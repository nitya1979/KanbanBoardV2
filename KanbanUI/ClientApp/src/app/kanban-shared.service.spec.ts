import { TestBed, inject } from '@angular/core/testing';

import { KanbanSharedService } from './kanban-shared.service';

describe('KanbanSharedService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [KanbanSharedService]
    });
  });

  it('should be created', inject([KanbanSharedService], (service: KanbanSharedService) => {
    expect(service).toBeTruthy();
  }));
});
