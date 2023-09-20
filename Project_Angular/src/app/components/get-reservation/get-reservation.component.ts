import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Reservation } from 'src/app/models/reservation.model';
import { ReservationService } from 'src/app/services/reservation.service';

@Component({
  selector: 'app-get-reservation',
  templateUrl: './get-reservation.component.html',
  styleUrls: ['./get-reservation.component.css']
})
export class GetReservationComponent implements OnInit {
  reservationId: number = 0;
  reservation: Reservation = new Reservation();

  constructor(
    private actRoute: ActivatedRoute,
    private router: Router,
    private reservationService: ReservationService) {}

  async ngOnInit(): Promise<void> {
    const id = this.actRoute.snapshot.paramMap.get('id');
    if(id){
      this.reservationId = +id;
      await this.reservationService
      .GetReservationById(this.reservationId)
      .then((data) => {
        if (data.success) {
          this.reservation = data.result_set;
        } else {
          alert(data.userMessage);
        }
      })
      .catch((error) => {
        alert('Error ' + error.status + ': ' + error.error.userMessage);
        this.router.navigate(['/']);
      })
    }
    else{
      this.router.navigate(['/']);
    }
  }

  async DeleteReservation() {
    await this.reservationService
      .DeleteReservation(this.reservationId)
      .then((data) => {
        if (data.success) {
          alert('Reservation was deleted successfully.');
          this.router.navigate(['/GetReservations']);
        } else {
          alert(data.userMessage);
        }
      })
      .catch((error) => {
        alert('Error ' + error.status + ': ' + error.error.userMessage);
      });
  }
  
  async UpdateReservation() {
    this.router.navigate(['/UpdateReservation/' + this.reservation.id]);
  }
}
