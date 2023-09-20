import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetLectureComponent } from './get-lecture.component';

describe('GetLectureComponent', () => {
  let component: GetLectureComponent;
  let fixture: ComponentFixture<GetLectureComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GetLectureComponent]
    });
    fixture = TestBed.createComponent(GetLectureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
