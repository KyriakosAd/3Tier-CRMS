import { Component, OnInit } from '@angular/core';
import { Lecture } from 'src/app/models/lecture.model';
import { LectureService } from 'src/app/services/lecture.service';

@Component({
  selector: 'app-get-lectures',
  templateUrl: './get-lectures.component.html',
  styleUrls: ['./get-lectures.component.css']
})
export class GetLecturesComponent implements OnInit {
  lectures: Lecture[] = [];
  load: string = 'no-show';
  disabled: string = '';
  constructor(private lectureService: LectureService) {}

  async ngOnInit(): Promise<void> {
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
}
