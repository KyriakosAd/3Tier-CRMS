import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-get-users',
  templateUrl: './get-users.component.html',
  styleUrls: ['./get-users.component.css']
})
export class GetUsersComponent implements OnInit {
  users: User[] = [];
  load: string = 'no-show';
  disabled: string = '';
  constructor(private userService: UserService) {}

  async ngOnInit(): Promise<void> {
    await this.userService
      .GetUsers()
      .then((data) => {
        if (data.success) {
          this.users = data.result_set;
        } else {
          alert(data.userMessage);
        }
      })
      .catch((error) => {
        alert('Error ' + error.status + ': ' + error.error.userMessage);
      })
  }
}
