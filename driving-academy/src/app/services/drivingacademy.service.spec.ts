import { TestBed } from '@angular/core/testing';

import { DrivingacademyService } from './drivingacademy.service';

describe('DrivingacademyService', () => {
  let service: DrivingacademyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DrivingacademyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
