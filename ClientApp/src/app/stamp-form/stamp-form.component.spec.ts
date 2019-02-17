import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StampFormComponent } from './stamp-form.component';

describe('StampFormComponent', () => {
  let component: StampFormComponent;
  let fixture: ComponentFixture<StampFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StampFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StampFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
