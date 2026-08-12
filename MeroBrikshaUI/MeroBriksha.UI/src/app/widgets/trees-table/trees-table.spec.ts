import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TreesTable } from './trees-table';

describe('TreesTable', () => {
  let component: TreesTable;
  let fixture: ComponentFixture<TreesTable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TreesTable],
    }).compileComponents();

    fixture = TestBed.createComponent(TreesTable);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
