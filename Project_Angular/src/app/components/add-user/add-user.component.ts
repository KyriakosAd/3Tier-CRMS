import { Component } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent {
  currentUser: User = new User();
  load: string = 'no-show';
  disabled: string = '';
  resultUser: User = new User(); 
  constructor(private userService: UserService) {}

  async SubmitUser() {
    if(this.currentUser.isValid()){
      this.disabled = 'disabled';
      this.load = '';
      await this.userService
        .AddUser(this.currentUser)
        .then((data) => {
          if (data.success) {
            alert('User was submitted successfully.');
            this.resultUser = data.result_set;
          } else {
            alert(data.userMessage);
          }
          this.currentUser = new User();
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
