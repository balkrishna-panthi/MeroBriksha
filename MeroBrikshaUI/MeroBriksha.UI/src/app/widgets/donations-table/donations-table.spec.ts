import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DonationsTable } from './donations-table';

describe('DonationsTable', () => {
  let component: DonationsTable;
  let fixture: ComponentFixture<DonationsTable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DonationsTable],
    }).compileComponents();

    fixture = TestBed.createComponent(DonationsTable);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
