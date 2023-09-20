import { Component, OnInit } from '@angular/core';
import { Reservation } from 'src/app/models/reservation.model';
import { ReservationService } from 'src/app/services/reservation.service';

@Component({
  selector: 'app-get-reservations',
  templateUrl: './get-reservations.component.html',
  styleUrls: ['./get-reservations.component.css']
})
export class GetReservationsComponent implements OnInit {
  reservations: Reservation[] = [];
  load: string = 'no-show';
  disabled: string = '';

  constructor(private reservationService: ReservationService) {}

  async ngOnInit() {
    await this.GetReservations();
  }

  async GetReservations(): Promise<void> {
    await this.reservationService
      .GetReservations()
      .then((data) => {
        if (data.success) {
          this.reservations = data.result_set;
        } else {
          alert(data.userMessage);
        }
      })
      .catch((error) => {
        alert('Error ' + error.status + ': ' + error.error.userMessage);
      })
  }
}
