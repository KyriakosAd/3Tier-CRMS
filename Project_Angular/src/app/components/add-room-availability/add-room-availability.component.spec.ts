import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRoomAvailabilityComponent } from './add-room-availability.component';

describe('AddRoomAvailabilityComponent', () => {
  let component: AddRoomAvailabilityComponent;
  let fixture: ComponentFixture<AddRoomAvailabilityComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddRoomAvailabilityComponent]
    });
    fixture = TestBed.createComponent(AddRoomAvailabilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
