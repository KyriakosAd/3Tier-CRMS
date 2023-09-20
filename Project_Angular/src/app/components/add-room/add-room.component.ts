import { Component } from '@angular/core';
import { Room } from 'src/app/models/room.model';
import { RoomService } from 'src/app/services/room.service';

@Component({
  selector: 'app-add-room',
  templateUrl: './add-room.component.html',
  styleUrls: ['./add-room.component.css']
})
export class AddRoomComponent {
  currentRoom: Room = new Room();
  load: string = 'no-show';
  disabled: string = '';
  resultRoom: Room = new Room(); 
  constructor(private roomService: RoomService) {}

  async SubmitRoom() {
    if(this.currentRoom.type == 1){
      this.currentRoom.computersCount = 0;
    }
    if(this.currentRoom.isValid()){
      this.disabled = 'disabled';
      this.load = '';
      await this.roomService
        .AddRoom(this.currentRoom)
        .then((data) => {
          if (data.success) {
            alert('Room was submitted successfully.');
            this.resultRoom = data.result_set;
          } else {
            alert(data.userMessage);
          }
          this.currentRoom = new Room();
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
