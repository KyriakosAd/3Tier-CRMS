import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Lecture } from 'src/app/models/lecture.model';
import { LectureService } from 'src/app/services/lecture.service';

@Component({
  selector: 'app-update-lecture',
  templateUrl: './update-lecture.component.html',
  styleUrls: ['./update-lecture.component.css']
})
export class UpdateLectureComponent implements OnInit {
  lectureId: number = 0;
  lecture: Lecture = new Lecture();
  lectureUpdated: Lecture = new Lecture();
  load: string = 'no-show';
  disabled: string = '';

  constructor(
    private actRoute: ActivatedRoute,
    private router: Router,
    private lectureService: LectureService) {}
  
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
    }
    else{
      this.router.navigate(['/']);
    }
  }

  async UpdateLecture() {
    this.lectureUpdated.id = this.lectureId;
    if(this.lectureUpdated.isValid()){
      this.disabled = 'disabled';
      this.load = '';
      await this.lectureService
        .UpdateLecture(this.lectureUpdated)
        .then((data) => {
          if (data.success) {
            alert('Lecture was updated successfully.');
            this.lecture = data.result_set;
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
