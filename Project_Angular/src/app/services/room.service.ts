import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { Room } from 'src/app/models/room.model';

@Injectable({
  providedIn: 'root'
})
export class RoomService {
  constructor(private http: HttpClient) { }

  async AddRoom(room: Room): Promise<any> {
    const result$ = await this.http
      .post<any>(
        'http://localhost:31365/api/Room/AddRoom',
        room
      )
    return lastValueFrom(result$)
  }

  async GetRooms(): Promise<any> {
    const rooms$ = await this.http
      .get<any>('http://localhost:31365/api/Room/GetAllRooms')
    return await lastValueFrom(rooms$)
  }

  async GetRoomById(roomId: number): Promise<any> {
    const room$ = await this.http
      .get<any>(`http://localhost:31365/api/Room/GetRoomById?id=${roomId}`)
    return await lastValueFrom(room$);
  }

  async DeleteRoom(roomId: number): Promise<any> {
    const result$ = await this.http
      .delete<any>(`http://localhost:31365/api/Room/DeleteRoom?id=${roomId}`)
    return await lastValueFrom(result$);
  }

  async UpdateRoom(room: Room): Promise<any> {
    const result$ = await this.http
      .post<any>(
        `http://localhost:31365/api/Room/UpdateRoom`,
        room
      )
    return await lastValueFrom(result$);
  }

  async GetRoomsByCapacity(minCapacity: number): Promise<any> {
    const rooms$ = await this.http
      .get<any>(`http://localhost:31365/api/Room/GetRoomsByCapacity?minCapacity=${minCapacity}`)
    return await lastValueFrom(rooms$)
  }

  async GetRoomsByDay(day: number): Promise<any> {
    const rooms$ = await this.http
      .get<any>(`http://localhost:31365/api/Room/GetRoomsByDayAvailable?day=${day}`)
    return await lastValueFrom(rooms$)
  }
  
  async GetRoomsByTime(startTime: number, endTime:number): Promise<any> {
    const rooms$ = await this.http
      .get<any>(`http://localhost:31365/api/Room/GetRoomsByTimeAvailable?startTime=${startTime}&endTime=${endTime}`)
    return await lastValueFrom(rooms$)
  }
}
