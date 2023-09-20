import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { TeacherLecture } from '../models/teacher-lecture.model';

@Injectable({
  providedIn: 'root'
})
export class TeacherLectureService {
  constructor(private http: HttpClient) { }

  async AddTeacherLecture(teacherLecture: TeacherLecture): Promise<any> {
    const result$ = await this.http
      .post<any>(
        'http://localhost:31365/api/TeacherLecture/AddTeacherLecture',
        teacherLecture
      )
    return lastValueFrom(result$)
  }

  async GetTeachersOfLecture(id: number): Promise<any> {
    const teachers$ = await this.http
      .get<any>(`http://localhost:31365/api/TeacherLecture/GetTeachersOfLecture?id=${id}`)
    return await lastValueFrom(teachers$)
  }
}
