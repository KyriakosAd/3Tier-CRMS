import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { Teacher } from 'src/app/models/teacher.model';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  constructor(private http: HttpClient) { }

  async AddTeacher(teacher: Teacher): Promise<any> {
    const result$ = await this.http
      .post<any>(
        'http://localhost:31365/api/Teacher/AddTeacher',
        teacher
      )
    return lastValueFrom(result$)
  }

  async GetTeachers(): Promise<any> {
    const teachers$ = await this.http
      .get<any>('http://localhost:31365/api/Teacher/GetAllTeachers')
    return await lastValueFrom(teachers$)
  }

  async GetTeacherById(teacherId: number): Promise<any> {
    const teacher$ = await this.http
      .get<any>(`http://localhost:31365/api/Teacher/GetTeacherById?id=${teacherId}`)
    return await lastValueFrom(teacher$);
  }

  async DeleteTeacher(teacherId: number): Promise<any> {
    const result$ = await this.http
      .delete<any>(`http://localhost:31365/api/Teacher/DeleteTeacher?id=${teacherId}`)
    return await lastValueFrom(result$);
  }

  async UpdateTeacher(teacher: Teacher): Promise<any> {
    const result$ = await this.http
      .post<any>(
        `http://localhost:31365/api/Teacher/UpdateTeacher`,
        teacher
      )
    return await lastValueFrom(result$);
  }
}
