import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { RoomAvailability } from 'src/app/models/room-availability.model';

@Injectable({
  providedIn: 'root'
})
export class RoomAvailabilityService {
  constructor(private http: HttpClient) { }

  async AddRoomAvailability(roomAvailability: RoomAvailability): Promise<any> {
    const result$ = await this.http
      .post<any>(
        'http://localhost:31365/api/RoomAvailability/AddRoomAvailability',
        roomAvailability
      )
    return lastValueFrom(result$)
  }

  async GetRoomAvailabilitiesByRoom(roomId: number): Promise<any> {
    const roomAvailabilities$ = await this.http
      .get<any>(`http://localhost:31365/api/RoomAvailability/GetRoomAvailabilitiesByRoom?roomId=${roomId}`)
    return await lastValueFrom(roomAvailabilities$)
  }
}
