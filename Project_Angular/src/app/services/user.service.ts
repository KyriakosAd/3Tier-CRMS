import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { User } from 'src/app/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) {}

  async AddUser(user: User): Promise<any> {
    const result$ = await this.http
      .post<any>(
        'http://localhost:31365/api/User/AddUser',
        user
      )
    return lastValueFrom(result$)
  }

  async GetUsers(): Promise<any> {
    const users$ = await this.http
      .get<any>('http://localhost:31365/api/User/GetAllUsers')
    return await lastValueFrom(users$)
  }

  async GetUserById(userId: number): Promise<any> {
    const user$ = await this.http
      .get<any>(`http://localhost:31365/api/User/GetUserById?id=${userId}`)
    return await lastValueFrom(user$);
  }

  async DeleteUser(userId: number): Promise<any> {
    const result$ = await this.http
      .delete<any>(`http://localhost:31365/api/User/DeleteUser?id=${userId}`)
    return await lastValueFrom(result$);
  }

  async UpdateUser(user: User): Promise<any> {
    const result$ = await this.http
      .post<any>(
        `http://localhost:31365/api/User/UpdateUser`,
        user
      )
    return await lastValueFrom(result$);
  }
}
