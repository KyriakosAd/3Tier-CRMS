import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetLecturesComponent } from './get-lectures.component';

describe('GetLecturesComponent', () => {
  let component: GetLecturesComponent;
  let fixture: ComponentFixture<GetLecturesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GetLecturesComponent]
    });
    fixture = TestBed.createComponent(GetLecturesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
