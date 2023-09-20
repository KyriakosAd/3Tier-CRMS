import { Component } from '@angular/core';
import { Lecture } from 'src/app/models/lecture.model';
import { LectureService } from 'src/app/services/lecture.service';

@Component({
  selector: 'app-add-lecture',
  templateUrl: './add-lecture.component.html',
  styleUrls: ['./add-lecture.component.css']
})
export class AddLectureComponent {
  currentLecture: Lecture = new Lecture();
  load: string = 'no-show';
  disabled: string = '';
  resultLecture: Lecture = new Lecture(); 
  constructor(private lectureService: LectureService) {}

  async SubmitLecture() {
    if(this.currentLecture.isValid()){
      this.disabled = 'disabled';
      this.load = '';
      await this.lectureService
        .AddLecture(this.currentLecture)
        .then((data) => {
          if (data.success) {
            alert('Lecture was submitted successfully.');
            this.resultLecture = data.result_set;
          } else {
            alert(data.userMessage);
          }
          this.currentLecture = new Lecture();
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
