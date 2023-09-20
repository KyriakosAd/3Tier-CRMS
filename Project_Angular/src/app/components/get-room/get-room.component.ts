import { Component, OnInit } from '@angular/core';
import { Room } from 'src/app/models/room.model';
import { RoomAvailability } from 'src/app/models/room-availability.model';
import { RoomService } from 'src/app/services/room.service';
import { RoomAvailabilityService } from 'src/app/services/room-availability.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-get-room',
  templateUrl: './get-room.component.html',
  styleUrls: ['./get-room.component.css']
})
export class GetRoomComponent implements OnInit {
  roomId: number = 0;
  room: Room = new Room();
  roomAvailabilities: RoomAvailability[] = [];

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
    
    async DeleteRoom() {
      await this.roomService
        .DeleteRoom(this.roomId)
        .then((data) => {
          if (data.success) {
            alert('Room was deleted successfully.');
            this.router.navigate(['/GetRooms']);
          } else {
            alert(data.userMessage);
          }
        })
        .catch((error) => {
          alert('Error ' + error.status + ': ' + error.error.userMessage);
        });
    }
    
    async UpdateRoom() {
      this.router.navigate(['/UpdateRoom/' + this.room.id]);
    }
}
