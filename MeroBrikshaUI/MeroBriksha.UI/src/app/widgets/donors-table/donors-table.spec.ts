import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DonorsTable } from './donors-table';

describe('DonorsTable', () => {
  let component: DonorsTable;
  let fixture: ComponentFixture<DonorsTable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DonorsTable],
    }).compileComponents();

    fixture = TestBed.createComponent(DonorsTable);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
