import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.css']
})
export class UpdateUserComponent implements OnInit {
  userId: number = 0;
  user: User = new User();
  userUpdated: User = new User();
  load: string = 'no-show';
  disabled: string = '';

  constructor(
    private actRoute: ActivatedRoute,
    private router: Router,
    private userService: UserService) {}
  
  async ngOnInit(): Promise<void> {
    const id = this.actRoute.snapshot.paramMap.get('id');
    if(id){
      this.userId = +id;
      await this.userService
      .GetUserById(this.userId)
      .then((data) => {
        if (data.success) {
          this.user = data.result_set;
        } else {
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

  async UpdateUser() {
    this.userUpdated.id = this.userId;
    if(this.userUpdated.isValid()){
      this.disabled = 'disabled';
      this.load = '';
      await this.userService
        .UpdateUser(this.userUpdated)
        .then((data) => {
          if (data.success) {
            alert('User was updated successfully.');
            this.user = data.result_set;
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
