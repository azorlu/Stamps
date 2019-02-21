import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StampListComponent } from './stamp-list.component';

describe('StampListComponent', () => {
  let component: StampListComponent;
  let fixture: ComponentFixture<StampListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StampListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StampListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
