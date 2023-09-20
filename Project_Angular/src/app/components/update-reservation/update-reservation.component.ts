import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Reservation } from 'src/app/models/reservation.model';
import { Room } from 'src/app/models/room.model';
import { ReservationService } from 'src/app/services/reservation.service';
import { RoomAvailabilityService } from 'src/app/services/room-availability.service';
import { RoomService } from 'src/app/services/room.service';
import { RoomAvailability } from 'src/app/models/room-availability.model';

@Component({
  selector: 'app-update-reservation',
  templateUrl: './update-reservation.component.html',
  styleUrls: ['./update-reservation.component.css']
})
export class UpdateReservationComponent {
  reservationId: number = 0;

  tempStartTime: Date = new Date();
  tempEndTime: Date = new Date();
  minStartTime: Date = new Date();
  minEndTime: Date = new Date();
  maxStartTime: Date = new Date();
  maxEndTime: Date = new Date();

  tempReservation: Reservation = new Reservation();
  reservation: Reservation = new Reservation();
  reservationUpdated: Reservation = new Reservation();
  roomAvailabilities: RoomAvailability[] = [];
  rooms: Room[] = [];
  reservations: Reservation[] = [];
  load: string = 'no-show';
  disabled: string = '';

  constructor(
    private actRoute: ActivatedRoute,
    private router: Router,
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

  async ngOnInit(): Promise<void> {
    const id = this.actRoute.snapshot.paramMap.get('id');
    if(id){
      this.reservationId = +id;

      this.reservationUpdated.startTime = this.tempStartTime.getHours() * 100 + this.tempStartTime.getMinutes();
      this.reservationUpdated.endTime = this.tempEndTime.getHours() * 100 + this.tempEndTime.getMinutes();
      await this.reservationService
      .GetReservationById(this.reservationId)
      .then((data) => {
        if (data.success) {
          this.reservation = data.result_set;
          this.tempReservation = data.result_set;
        } else {
          alert(data.userMessage);
        }
      })
      .catch((error) => {
        alert('Error ' + error.status + ': ' + error.error.userMessage);
        this.router.navigate(['/']);
      })
      
      await this.roomService
      .GetRooms()
      .then((data) => {
        if (data.success) {
          this.rooms = data.result_set;
        } else{
          alert(data.userMessage);
        }
      })
      .catch((error) => {
        alert('Error ' + error.status + ': ' + error.error.userMessage);
        this.router.navigate(['/']);
      })
    }
    else{
      this.router.navigate(['/']);
    }
  }
  
  async UpdateReservation() {
    this.reservationUpdated.id = this.reservationId;
    this.reservationUpdated.entryDate = this.tempReservation.entryDate;
    this.reservationUpdated.isRecurring = this.tempReservation.isRecurring;
    this.reservationUpdated.startDate = this.tempReservation.startDate;
    this.reservationUpdated.endDate = this.tempReservation.endDate;
    this.reservationUpdated.exactDate = this.tempReservation.exactDate;
    this.reservationUpdated.day = this.tempReservation.day;

    if(this.reservationUpdated.isValid()){
      if(this.reservationUpdated.timeValid()){
          if(this.checkAvailability()){
            if(this.checkReservations()){
              this.disabled = 'disabled';
              this.load = '';
              await this.reservationService
                .UpdateReservation(this.reservationUpdated)
                .then((data) => {
                  if (data.success) {
                    alert('Reservation was updated successfully.');
                    this.reservation = data.result_set;
                    this.GetRoomReservations(this.reservationUpdated.roomId);
                  } else {
                    alert(data.userMessage);
                  }
                  this.reservationUpdated.startTime = this.tempStartTime.getHours() * 100 + this.tempStartTime.getMinutes();
                  this.reservationUpdated.endTime = this.tempEndTime.getHours() * 100 + this.tempEndTime.getMinutes();
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
          alert('Room is not available for the time selected.')
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
      if (roomAvailability.startTime <= this.reservationUpdated.startTime && roomAvailability.endTime >= this.reservationUpdated.endTime){
        if((this.reservationUpdated.isRecurring && this.reservationUpdated.day == roomAvailability.day) || 
            ((!this.reservationUpdated.isRecurring) && (this.getDayNumber(this.reservationUpdated.exactDate) == roomAvailability.day))){
          flag = true;
        }
      }
    }
    return flag;
  }

  checkReservations(): boolean {
    for(const reservation of this.reservations){
      if(this.reservationUpdated.id == reservation.id){
        continue;
      }
      else if(this.reservationUpdated.startTime >= reservation.endTime || this.reservationUpdated.endTime <= reservation.startTime){
        continue;
      }
      else if(reservation.isRecurring && this.reservationUpdated.isRecurring){
        if(this.biggerThanDates(this.reservationUpdated.startDate, reservation.endDate) || this.biggerThanDates(reservation.startDate, this.reservationUpdated.endDate)){
          continue;
        }
        else if(this.reservationUpdated.day != reservation.day){
          continue;
        }
      }
      else if((!reservation.isRecurring) && this.reservationUpdated.isRecurring){
        if(this.biggerThanDates(this.reservationUpdated.startDate, reservation.exactDate) || this.biggerThanDates(reservation.exactDate, this.reservationUpdated.endDate)){
          continue;
        }
        else if(this.getDayNumber(reservation.exactDate) != this.reservationUpdated.day){
          continue;
        }
      }
      else if(reservation.isRecurring && (!this.reservationUpdated.isRecurring)){
        if(this.biggerThanDates(reservation.startDate, this.reservationUpdated.exactDate) || this.biggerThanDates(this.reservationUpdated.exactDate, reservation.endDate)){
          continue;
        }
        else if(this.getDayNumber(this.reservationUpdated.exactDate) != reservation.day){
          continue;
        }
      }
      else if((!reservation.isRecurring) && (!this.reservationUpdated.isRecurring)){
        if(!this.equalDates(reservation.exactDate, this.reservationUpdated.exactDate)){
          continue;
        }
      }
      return false;
    }
    return true;
  }
}
