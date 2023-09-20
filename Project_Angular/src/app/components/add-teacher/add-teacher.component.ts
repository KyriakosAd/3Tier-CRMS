import { Component, OnInit } from '@angular/core';
import { Teacher } from 'src/app/models/teacher.model';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';
import { TeacherService } from 'src/app/services/teacher.service';

@Component({
  selector: 'app-add-teacher',
  templateUrl: './add-teacher.component.html',
  styleUrls: ['./add-teacher.component.css']
})
export class AddTeacherComponent implements OnInit{
  users: User[] = [];
  currentTeacher: Teacher = new Teacher();
  load: string = 'no-show';
  disabled: string = '';
  resultTeacher: Teacher = new Teacher(); 
  constructor(private teacherService: TeacherService,
    private userService: UserService) {}

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

  async SubmitTeacher() {
    if(this.currentTeacher.isValid()){
      this.disabled = 'disabled';
      this.load = '';
      await this.teacherService
        .AddTeacher(this.currentTeacher)
        .then((data) => {
          if (data.success) {
            alert('Teacher was submitted successfully.');
            this.resultTeacher = data.result_set;
          } else {
            alert(data.userMessage);
          }
          this.currentTeacher = new Teacher();
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