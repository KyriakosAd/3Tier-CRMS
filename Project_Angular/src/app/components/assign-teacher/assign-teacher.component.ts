import { Component, OnInit } from '@angular/core';
import { Lecture } from 'src/app/models/lecture.model';
import { TeacherLecture } from 'src/app/models/teacher-lecture.model';
import { Teacher } from 'src/app/models/teacher.model';
import { LectureService } from 'src/app/services/lecture.service';
import { TeacherLectureService } from 'src/app/services/teacher-lecture.service';
import { TeacherService } from 'src/app/services/teacher.service';

@Component({
  selector: 'app-assign-teacher',
  templateUrl: './assign-teacher.component.html',
  styleUrls: ['./assign-teacher.component.css']
})
export class AssignTeacherComponent implements OnInit {
  teachers: Teacher[] = [];
  lectures: Lecture[] = [];
  
  currentTeacherLecture: TeacherLecture = new TeacherLecture();
  load: string = 'no-show';
  disabled: string = '';
  resultTeacherLecture: TeacherLecture = new TeacherLecture(); 
  constructor(private teacherLectureService: TeacherLectureService,
    private teacherService: TeacherService,
    private lectureService: LectureService) {}
   
  async ngOnInit(): Promise<void> {
    await this.teacherService
      .GetTeachers()
      .then((data) => {
        if (data.success) {
          this.teachers = data.result_set;
        } else {
          alert(data.userMessage);
        }
      })
      .catch((error) => {
        alert('Error ' + error.status + ': ' + error.error.userMessage);
      })
      
    await this.lectureService
      .GetLectures()
      .then((data) => {
        if (data.success) {
          this.lectures = data.result_set;
        } else {
          alert(data.userMessage);
        }
      })
      .catch((error) => {
        alert('Error ' + error.status + ': ' + error.error.userMessage);
      })
  }

  async SubmitTeacherLecture() {
    if(this.currentTeacherLecture.isValid()){
      this.disabled = 'disabled';
      this.load = '';
      await this.teacherLectureService
        .AddTeacherLecture(this.currentTeacherLecture)
        .then((data) => {
          if (data.success) {
            alert('Teacher - Lecture was submitted successfully.');
            this.resultTeacherLecture = data.result_set;
          } else {
            alert(data.userMessage);
          }
          this.currentTeacherLecture = new TeacherLecture();
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
