import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-get-user',
  templateUrl: './get-user.component.html',
  styleUrls: ['./get-user.component.css']
})
export class GetUserComponent implements OnInit {
  userId: number = 0;
  user: User = new User();

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
  
  async DeleteUser() {
    await this.userService
      .DeleteUser(this.userId)
      .then((data) => {
        if (data.success) {
          alert('User was deleted successfully.');
          this.router.navigate(['/GetUsers']);
        } else {
          alert(data.userMessage);
        }
      })
      .catch((error) => {
        alert('Error ' + error.status + ': ' + error.error.userMessage);
      });
  }
  
  async UpdateUser() {
    this.router.navigate(['/UpdateUser/' + this.user.id]);
  }
}
