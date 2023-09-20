import { Component, OnInit } from '@angular/core';
import { RoomAvailability } from 'src/app/models/room-availability.model';
import { RoomAvailabilityService } from 'src/app/services/room-availability.service';
import { RoomService } from 'src/app/services/room.service';

@Component({
  selector: 'app-add-room-availability',
  templateUrl: './add-room-availability.component.html',
  styleUrls: ['./add-room-availability.component.css']
})
export class AddRoomAvailabilityComponent implements OnInit {
  tempStartTime: Date = new Date();
  tempEndTime: Date = new Date();
  minStartTime: Date = new Date();
  minEndTime: Date = new Date();
  maxStartTime: Date = new Date();
  maxEndTime: Date = new Date();

  rooms: any[] = [];
  currentRoomAvailability: RoomAvailability = new RoomAvailability();
  load: string = 'no-show';
  disabled: string = '';
  resultRoomAvailability: RoomAvailability = new RoomAvailability();

  constructor(
    private roomAvailabilityService: RoomAvailabilityService,
    private roomService: RoomService,
    ) {
      this.minStartTime.setHours(8);
      this.minStartTime.setMinutes(59);
      this.maxStartTime.setHours(21);
      this.maxStartTime.setMinutes(1);

      this.minEndTime.setHours(9);
      this.minEndTime.setMinutes(59);
      this.maxEndTime.setHours(21);
      this.maxEndTime.setMinutes(1);

      this.tempStartTime.setHours(9);
      this.tempStartTime.setMinutes(0);
      this.tempEndTime.setHours(10);
      this.tempEndTime.setMinutes(0);
    }
  
  async SubmitRoomAvailability() {
    if(this.currentRoomAvailability.isValid()){
      if(this.currentRoomAvailability.timeValid()){
        this.disabled = 'disabled';
        this.load = '';
        await this.roomAvailabilityService
          .AddRoomAvailability(this.currentRoomAvailability)
          .then((data) => {
            if (data.success) {
              alert('Room Availability was submitted successfully.');
              this.resultRoomAvailability = data.result_set;
            } else {
              alert(data.userMessage);
            }
            this.currentRoomAvailability = new RoomAvailability();
            this.currentRoomAvailability.startTime = this.tempStartTime.getHours() * 100 + this.tempStartTime.getMinutes();
            this.currentRoomAvailability.endTime = this.tempEndTime.getHours() * 100 + this.tempEndTime.getMinutes();
          })
          .catch((error) => {
            alert('Error ' + error.status + ': ' + error.error.userMessage);
          });
        this.disabled = '';
        this.load = 'no-show';
      }
      else{
        alert('Time values selected are invalid.');
      }
    }
    else{
      alert('Make sure you have entered all values.');
    }
  }

  async ngOnInit(): Promise<void> {
    this.currentRoomAvailability.startTime = this.tempStartTime.getHours() * 100 + this.tempStartTime.getMinutes();
    this.currentRoomAvailability.endTime = this.tempEndTime.getHours() * 100 + this.tempEndTime.getMinutes();
    await this.roomService
      .GetRooms()
      .then((data) => {
        if (data.success) {
          this.rooms = data.result_set;
        } else {
          alert(data.userMessage);
        }
      })
      .catch((error) => {
        alert('Error ' + error.status + ': ' + error.error.userMessage);
      })
  }

  getRoomName(roomId: number): string {
    let room = this.rooms.find(room => room.id == roomId);
    return room ? room.name : '';
  }
}
