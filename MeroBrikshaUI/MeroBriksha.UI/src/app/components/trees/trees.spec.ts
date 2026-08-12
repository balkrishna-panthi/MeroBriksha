import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Trees } from './trees';

describe('Trees', () => {
  let component: Trees;
  let fixture: ComponentFixture<Trees>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Trees],
    }).compileComponents();

    fixture = TestBed.createComponent(Trees);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
