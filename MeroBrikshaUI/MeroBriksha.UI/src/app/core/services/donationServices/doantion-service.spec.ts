import { TestBed } from '@angular/core/testing';

import { DoantionService } from './doantion-service';

describe('DoantionService', () => {
  let service: DoantionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DoantionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
