import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CampaignTable } from './campaign-table';

describe('CampaignTable', () => {
  let component: CampaignTable;
  let fixture: ComponentFixture<CampaignTable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CampaignTable],
    }).compileComponents();

    fixture = TestBed.createComponent(CampaignTable);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
