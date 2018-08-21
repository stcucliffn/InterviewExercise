import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpinnyComponent } from './spinny.component';

describe('SpinnyComponent', () => {
  let component: SpinnyComponent;
  let fixture: ComponentFixture<SpinnyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpinnyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpinnyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
