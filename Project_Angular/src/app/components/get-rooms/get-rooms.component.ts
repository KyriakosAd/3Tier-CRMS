import { Component, OnInit } from '@angular/core';
import { Room } from 'src/app/models/room.model';
import { RoomService } from 'src/app/services/room.service';

@Component({
  selector: 'app-get-rooms',
  templateUrl: './get-rooms.component.html',
  styleUrls: ['./get-rooms.component.css']
})
export class GetRoomsComponent implements OnInit {
  filter: number = 0;

  capacityFilter: number = 0;
  dayFilter: number = 0;
  startTimeFilter: number = 0;
  endTimeFilter: number = 0;

  tempStartTimeFilter: Date = new Date();
  tempEndTimeFilter: Date = new Date();
  minStartTimeFilter: Date = new Date();
  minEndTimeFilter: Date = new Date();
  maxStartTimeFilter: Date = new Date();
  maxEndTimeFilter: Date = new Date();

  rooms: Room[] = [];
  load: string = 'no-show';
  disabled: string = '';
  constructor(private roomService: RoomService) {
    this.minStartTimeFilter.setHours(8);
    this.minStartTimeFilter.setMinutes(59);
    this.maxStartTimeFilter.setHours(21);
    this.maxStartTimeFilter.setMinutes(1);

    this.minEndTimeFilter.setHours(9);
    this.minEndTimeFilter.setMinutes(59);
    this.maxEndTimeFilter.setHours(21);
    this.maxEndTimeFilter.setMinutes(1);

    this.tempStartTimeFilter.setHours(9);
    this.tempStartTimeFilter.setMinutes(0);
    this.tempEndTimeFilter.setHours(10);
    this.tempEndTimeFilter.setMinutes(0);
  }

  async ngOnInit() {
    this.startTimeFilter = this.tempStartTimeFilter.getHours() * 100 + this.tempStartTimeFilter.getMinutes();
    this.endTimeFilter = this.tempEndTimeFilter.getHours() * 100 + this.tempEndTimeFilter.getMinutes();
    await this.GetRooms();
  }
    
  async GetRooms(): Promise<void> {
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

  async GetRoomsByCapacity(): Promise<void> {
    if(this.capacityFilter !== null && this.capacityFilter >= 0){
    await this.roomService
      .GetRoomsByCapacity(this.capacityFilter)
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
    else{
      alert('Capacity value selected is invalid.');
    }
  }

  async GetRoomsByDay(): Promise<void> {
    if(this.dayFilter !== null && this.dayFilter > 0 && this.dayFilter < 8){
      await this.roomService
      .GetRoomsByDay(this.dayFilter)
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
    else{
      alert('Make sure you have selected a day.');
    }
  }

  async GetRoomsByTime(): Promise<void> {
    if(this.startTimeFilter !== null && this.endTimeFilter !== null && this.endTimeFilter > this.startTimeFilter)(
      await this.roomService
      .GetRoomsByTime(this.startTimeFilter, this.endTimeFilter)
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
    )
    else{
      alert('Time values selected are invalid.');
    }
  }

  async SetFilter() {
    if(this.filter == 1){
      await this.GetRoomsByCapacity();
    }
    else if(this.filter == 2){
      await this.GetRoomsByDay();
    }
    else if(this.filter == 3){
      await this.GetRoomsByTime();
    }
    else{
      alert('Try selecting a filter first.');
    }
  }

  async ClearFilter() {
    this.filter = 0;
    this.capacityFilter = 0;
    this.dayFilter = 0;
    this.tempStartTimeFilter = new Date();
    this.tempEndTimeFilter = new Date();
    this.tempStartTimeFilter.setHours(9);
    this.tempStartTimeFilter.setMinutes(0);
    this.tempEndTimeFilter.setHours(10);
    this.tempEndTimeFilter.setMinutes(0);
    this.startTimeFilter = this.tempStartTimeFilter.getHours() * 100 + this.tempStartTimeFilter.getMinutes();
    this.endTimeFilter = this.tempEndTimeFilter.getHours() * 100 + this.tempEndTimeFilter.getMinutes();
    await this.GetRooms();
  }
}

