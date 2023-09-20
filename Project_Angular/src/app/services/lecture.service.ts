import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { Lecture } from 'src/app/models/lecture.model';

@Injectable({
  providedIn: 'root'
})
export class LectureService {
  constructor(private http: HttpClient) {}

  async AddLecture(lecture: Lecture): Promise<any> {
    const result$ = await this.http
      .post<any>(
        'http://localhost:31365/api/Lecture/AddLecture',
        lecture
      )
    return lastValueFrom(result$)
  }

  async GetLectures(): Promise<any> {
    const lectures$ = await this.http
      .get<any>('http://localhost:31365/api/Lecture/GetAllLectures')
    return await lastValueFrom(lectures$)
  }

  async GetLectureById(lectureId: number): Promise<any> {
    const lecture$ = await this.http
      .get<any>(`http://localhost:31365/api/Lecture/GetLectureById?id=${lectureId}`)
    return await lastValueFrom(lecture$);
  }

  async DeleteLecture(lectureId: number): Promise<any> {
    const result$ = await this.http
      .delete<any>(`http://localhost:31365/api/Lecture/DeleteLecture?id=${lectureId}`)
    return await lastValueFrom(result$);
  }

  async UpdateLecture(lecture: Lecture): Promise<any> {
    const result$ = await this.http
      .post<any>(
        `http://localhost:31365/api/Lecture/UpdateLecture`,
        lecture
      )
    return await lastValueFrom(result$);
  }
}
