import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { Reservation } from 'src/app/models/reservation.model';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  constructor(private http: HttpClient) { }

  async AddReservation(reservation: Reservation): Promise<any> {
    const result$ = await this.http
      .post<any>(
        'http://localhost:31365/api/Reservation/AddReservation',
        reservation
      )
    return lastValueFrom(result$)
  }

  async GetReservations(): Promise<any> {
    const reservations$ = await this.http
      .get<any>('http://localhost:31365/api/Reservation/GetAllReservations')
    return await lastValueFrom(reservations$)
  }

  async GetReservationById(id: number): Promise<any> {
    const reservation$ = await this.http
      .get<any>(`http://localhost:31365/api/Reservation/GetReservationById?id=${id}`)
    return await lastValueFrom(reservation$);
  }

  async DeleteReservation(id: number): Promise<any> {
    const result$ = await this.http
      .delete<any>(`http://localhost:31365/api/Reservation/DeleteReservation?id=${id}`)
    return await lastValueFrom(result$);
  }

  async UpdateReservation(reservation: Reservation): Promise<any> {
    const result$ = await this.http
      .post<any>(
        `http://localhost:31365/api/Reservation/UpdateReservation`,
        reservation
      )
    return await lastValueFrom(result$);
  }

  async GetReservationsByRoom(roomId: number): Promise<any> {
    const reservations$ = await this.http
      .get<any>(`http://localhost:31365/api/Reservation/GetReservationsByRoom?roomId=${roomId}`)
    return await lastValueFrom(reservations$)
  }
}
