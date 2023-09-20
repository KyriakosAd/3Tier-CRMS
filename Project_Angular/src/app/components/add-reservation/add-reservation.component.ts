import { Component, OnInit } from '@angular/core';
import { Reservation } from 'src/app/models/reservation.model';
import { ReservationService } from 'src/app/services/reservation.service';
import { RoomService } from 'src/app/services/room.service';
import { RoomAvailabilityService } from 'src/app/services/room-availability.service';
import { Room } from 'src/app/models/room.model';
import { RoomAvailability } from 'src/app/models/room-availability.model';

@Component({
  selector: 'app-add-reservation',
  templateUrl: './add-reservation.component.html',
  styleUrls: ['./add-reservation.component.css']
})
export class AddReservationComponent implements OnInit {
  minDate: Date = new Date();
  maxDate: Date = new Date(2023, 12, 0);

  tempStartTime: Date = new Date();
  tempEndTime: Date = new Date();
  minStartTime: Date = new Date();
  minEndTime: Date = new Date();
  maxStartTime: Date = new Date();
  maxEndTime: Date = new Date();

  rooms: Room[] = [];
  roomAvailabilities: RoomAvailability[] = [];
  reservations: Reservation[] = [];
  currentReservation: Reservation = new Reservation();
  load: string = 'no-show';
  disabled: string = '';
  resultReservation: Reservation = new Reservation(); 

  constructor(
    private reservationService: ReservationService,
    private roomService: RoomService,
    private roomAvailabilityService: RoomAvailabilityService,
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

  async SubmitReservation() {
    if(this.currentReservation.isRecurring){
      this.currentReservation.exactDate = new Date(0);
    }
    else if(!this.currentReservation.isRecurring){
      this.currentReservation.startDate = new Date(0);
      this.currentReservation.endDate = new Date(0);
      this.currentReservation.day = 0;
    }
    if(this.currentReservation.isValid()){
      if(this.currentReservation.timeValid()){
        if(this.currentReservation.dateValid()){
          if(this.checkAvailability()){
            if(this.checkReservations()){
              this.currentReservation.entryDate = new Date();
              
              this.disabled = 'disabled';
              this.load = '';
              if(this.currentReservation.isRecurring){
                this.currentReservation.startDate = new Date(Date.UTC(this.currentReservation.startDate.getFullYear(), this.currentReservation.startDate.getMonth(), this.currentReservation.startDate.getDate()));
                this.currentReservation.endDate = new Date(Date.UTC(this.currentReservation.endDate.getFullYear(), this.currentReservation.endDate.getMonth(), this.currentReservation.endDate.getDate()));
              }
              else if(!this.currentReservation.isRecurring){
                this.currentReservation.exactDate = new Date(Date.UTC(this.currentReservation.exactDate.getFullYear(), this.currentReservation.exactDate.getMonth(), this.currentReservation.exactDate.getDate()));
              }
              
              await this.reservationService
                .AddReservation(this.currentReservation)
                .then((data) => {
                  if (data.success) {
                    alert('Reservation was submitted successfully.');
                    this.resultReservation = data.result_set;
                  } else {
                    alert(data.userMessage);
                  }
                  this.currentReservation = new Reservation();
                  this.currentReservation.startTime = this.tempStartTime.getHours() * 100 + this.tempStartTime.getMinutes();
                  this.currentReservation.endTime = this.tempEndTime.getHours() * 100 + this.tempEndTime.getMinutes();
                })
                .catch((error) => {
                  alert('Error ' + error.status + ': ' + error.error.userMessage);
                });
              this.disabled = '';
              this.load = 'no-show';
            }
            else{
              alert('Room is already reserved for the time selected.')
            }
          }
          else{
            alert('Room is not available for the day or time selected.')
          }
        }
        else{
          alert('Date values selected are invalid.');
        }
      }
      else{
        alert('Time values selected are invalid.');
      }
    }
    else{
      alert('Make sure you have entered all values.');
    }
  }

  async GetRoomAvailabilities(roomId: number): Promise<void> {
    await this.roomAvailabilityService
    .GetRoomAvailabilitiesByRoom(roomId)
    .then((data) => {
      if (data.success) {
        this.roomAvailabilities = data.result_set;
      } else{
        alert(data.userMessage);
      }
    })
    .catch((error) => {
      alert('Error ' + error.status + ': ' + error.error.userMessage);
    })
  }

  async GetRoomReservations(roomId: number): Promise<void> {
    await this.reservationService
    .GetReservationsByRoom(roomId)
    .then((data) => {
      if (data.success) {
        this.reservations = data.result_set;
      } else{
        alert(data.userMessage);
      }
    })
    .catch((error) => {
      alert('Error ' + error.status + ': ' + error.error.userMessage);
    })
  }

  async ngOnInit(): Promise<void> {
    this.currentReservation.startTime = this.tempStartTime.getHours() * 100 + this.tempStartTime.getMinutes();
    this.currentReservation.endTime = this.tempEndTime.getHours() * 100 + this.tempEndTime.getMinutes();
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

  getDayNumber(inputDate: Date): number {
    let date = new Date(inputDate);
    return ((date.getDay() + 6) % 7 + 1);
  }

  equalDates(firstInputDate: Date, secondInputDate: Date): boolean {
    let firstDate = new Date(firstInputDate);
    let secondDate = new Date(secondInputDate);
    let flag = false;
    if(firstDate.getDate() == secondDate.getDate() && firstDate.getMonth() == secondDate.getMonth() && firstDate.getFullYear() == secondDate.getFullYear()){
      flag = true;
    }
    return flag;
  }

  biggerThanDates(firstInputDate: Date, secondInputDate: Date): boolean {
    let firstDate = new Date(firstInputDate);
    let secondDate = new Date(secondInputDate);
    let flag = false;
    if ((firstDate.getFullYear() > secondDate.getFullYear()) ||
      (firstDate.getFullYear() == secondDate.getFullYear() && firstDate.getMonth() > secondDate.getMonth()) ||
      (firstDate.getFullYear() == secondDate.getFullYear() && firstDate.getMonth() == secondDate.getMonth() && firstDate.getDate() > secondDate.getDate())) {
      flag = true;
    }
    return flag;
  }
  
  checkAvailability(): boolean {
    let flag = false;
    for(const roomAvailability of this.roomAvailabilities){
      if (roomAvailability.startTime <= this.currentReservation.startTime && roomAvailability.endTime >= this.currentReservation.endTime){
        if((this.currentReservation.isRecurring && this.currentReservation.day == roomAvailability.day) || 
            ((!this.currentReservation.isRecurring) && (this.getDayNumber(this.currentReservation.exactDate) == roomAvailability.day))){
          flag = true;
        }
      }
    }
    return flag;
  }

  checkReservations(): boolean {
    for(const reservation of this.reservations){
      if(this.currentReservation.startTime >= reservation.endTime || this.currentReservation.endTime <= reservation.startTime){
        continue;
      }
      else if(reservation.isRecurring && this.currentReservation.isRecurring){
        if(this.biggerThanDates(this.currentReservation.startDate, reservation.endDate) || this.biggerThanDates(reservation.startDate, this.currentReservation.endDate)){
          continue;
        }
        else if(this.currentReservation.day != reservation.day){
          continue;
        }
      }
      else if((!reservation.isRecurring) && this.currentReservation.isRecurring){
        if(this.biggerThanDates(this.currentReservation.startDate, reservation.exactDate) || this.biggerThanDates(reservation.exactDate, this.currentReservation.endDate)){
          continue;
        }
        else if(this.getDayNumber(reservation.exactDate) != this.currentReservation.day){
          continue;
        }
      }
      else if(reservation.isRecurring && (!this.currentReservation.isRecurring)){
        if(this.biggerThanDates(reservation.startDate, this.currentReservation.exactDate) || this.biggerThanDates(this.currentReservation.exactDate, reservation.endDate)){
          continue;
        }
        else if(this.getDayNumber(this.currentReservation.exactDate) != reservation.day){
          continue;
        }
      }
      else if((!reservation.isRecurring) && (!this.currentReservation.isRecurring)){
        if(!this.equalDates(reservation.exactDate, this.currentReservation.exactDate)){
          continue;
        }
      }
      return false;
    }
    return true;
  }
}
