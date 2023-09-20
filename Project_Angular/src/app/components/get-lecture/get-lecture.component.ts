
import { Component, OnInit } from '@angular/core';
import { Lecture } from 'src/app/models/lecture.model';
import { LectureService } from 'src/app/services/lecture.service';
import { ActivatedRoute, Router } from '@angular/router';
import { TeacherLectureService } from 'src/app/services/teacher-lecture.service';
import { Teacher } from 'src/app/models/teacher.model';

@Component({
  selector: 'app-get-lecture',
  templateUrl: './get-lecture.component.html',
  styleUrls: ['./get-lecture.component.css']
})
export class GetLectureComponent implements OnInit {
  lectureId: number = 0;
  lecture: Lecture = new Lecture();
  teachers: Teacher[] = [];

  constructor(
    private actRoute: ActivatedRoute,
    private router: Router,
    private lectureService: LectureService,
    private teacherLectureService: TeacherLectureService) {}

  async ngOnInit(): Promise<void> {
    const id = this.actRoute.snapshot.paramMap.get('id');
    if(id){
      this.lectureId = +id;
      await this.lectureService
      .GetLectureById(this.lectureId)
      .then((data) => {
        if (data.success) {
          this.lecture = data.result_set;
        } else {
          alert(data.userMessage);
        }
      })
      .catch((error) => {
        alert('Error ' + error.status + ': ' + error.error.userMessage);
        this.router.navigate(['/']);
      })

      await this.teacherLectureService
      .GetTeachersOfLecture(this.lectureId)
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
    }
    else{
      this.router.navigate(['/']);
    }
  }
  
  async DeleteLecture() {
    await this.lectureService
      .DeleteLecture(this.lectureId)
      .then((data) => {
        if (data.success) {
          alert('Lecture was deleted successfully.');
          this.router.navigate(['/GetLectures']);
        } else {
          alert(data.userMessage);
        }
      })
      .catch((error) => {
        alert('Error ' + error.status + ': ' + error.error.userMessage);
      });
  }
  
  async UpdateLecture() {
    this.router.navigate(['/UpdateLecture/' + this.lecture.id]);
  }
}
