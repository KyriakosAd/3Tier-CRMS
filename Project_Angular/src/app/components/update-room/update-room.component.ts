import { Component, OnInit } from '@angular/core';
import { Room } from 'src/app/models/room.model';
import { ActivatedRoute, Router } from '@angular/router';
import { RoomAvailabilityService } from 'src/app/services/room-availability.service';
import { RoomService } from 'src/app/services/room.service';
import { RoomAvailability } from 'src/app/models/room-availability.model';

@Component({
  selector: 'app-update-room',
  templateUrl: './update-room.component.html',
  styleUrls: ['./update-room.component.css']
})
export class UpdateRoomComponent implements OnInit {
  roomId: number = 0;
  room: Room = new Room();
  roomAvailabilities: RoomAvailability[] = [];
  roomUpdated: Room = new Room();
  load: string = 'no-show';
  disabled: string = '';

  constructor(
    private actRoute: ActivatedRoute,
    private router: Router,
    private roomAvailabilityService: RoomAvailabilityService,
    private roomService: RoomService) {}

  async ngOnInit(): Promise<void> {
    const id = this.actRoute.snapshot.paramMap.get('id');
    if(id){
      this.roomId = +id;
      await this.roomService
      .GetRoomById(this.roomId)
      .then((data) => {
        if (data.success) {
          this.room = data.result_set;
        } else {
          alert(data.userMessage);
        }
      })
      .catch((error) => {
        alert('Error ' + error.status + ': ' + error.error.userMessage);
        this.router.navigate(['/']);
      })
      
      await this.roomAvailabilityService
      .GetRoomAvailabilitiesByRoom(this.roomId)
      .then((data) => {
        if (data.success) {
          this.roomAvailabilities = data.result_set;
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

  async UpdateRoom() {
    this.roomUpdated.id = this.roomId;
    if(this.roomUpdated.isValid()){
      this.disabled = 'disabled';
      this.load = '';
      await this.roomService
        .UpdateRoom(this.roomUpdated)
        .then((data) => {
          if (data.success) {
            alert('Room was updated successfully.');
            this.room = data.result_set;
          } else {
            alert(data.userMessage);
          }
        })
        .catch((error) => {
          alert('Error ' + error.status + ': ' + error.error.userMessage);
        });
      this.disabled = '';
      this.load = 'no-show';
    }
    else{
      alert('Make sure you have entered all values.');
    }
  }
}
