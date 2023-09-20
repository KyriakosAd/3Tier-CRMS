import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetRoomsComponent } from './get-rooms.component';

describe('GetRoomsComponent', () => {
  let component: GetRoomsComponent;
  let fixture: ComponentFixture<GetRoomsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GetRoomsComponent]
    });
    fixture = TestBed.createComponent(GetRoomsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
