import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddUserComponent } from './components/add-user/add-user.component';
import { HomeComponent } from './components/home/home.component';
import { AddRoomComponent } from './components/add-room/add-room.component';
import { GetUsersComponent } from './components/get-users/get-users.component';
import { GetRoomsComponent } from './components/get-rooms/get-rooms.component';
import { AddRoomAvailabilityComponent } from './components/add-room-availability/add-room-availability.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TimepickerModule } from 'ngx-bootstrap/timepicker';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { GetRoomComponent } from './components/get-room/get-room.component';
import { UpdateRoomComponent } from './components/update-room/update-room.component';
import { AddReservationComponent } from './components/add-reservation/add-reservation.component';
import { GetReservationsComponent } from './components/get-reservations/get-reservations.component';
import { GetReservationComponent } from './components/get-reservation/get-reservation.component';
import { UpdateReservationComponent } from './components/update-reservation/update-reservation.component';
import { GetUserComponent } from './components/get-user/get-user.component';
import { UpdateUserComponent } from './components/update-user/update-user.component';
import { AddLectureComponent } from './components/add-lecture/add-lecture.component';
import { GetLecturesComponent } from './components/get-lectures/get-lectures.component';
import { GetLectureComponent } from './components/get-lecture/get-lecture.component';
import { UpdateLectureComponent } from './components/update-lecture/update-lecture.component';
import { AddTeacherComponent } from './components/add-teacher/add-teacher.component';
import { AssignTeacherComponent } from './components/assign-teacher/assign-teacher.component';

@NgModule({
  declarations: [
    AppComponent,
    AddUserComponent,
    HomeComponent,
    AddRoomComponent,
    GetUsersComponent,
    GetRoomsComponent,
    AddRoomAvailabilityComponent,
    GetRoomComponent,
    UpdateRoomComponent,
    AddReservationComponent,
    GetReservationsComponent,
    GetReservationComponent,
    UpdateReservationComponent,
    GetUserComponent,
    UpdateUserComponent,
    AddLectureComponent,
    GetLecturesComponent,
    GetLectureComponent,
    UpdateLectureComponent,
    AddTeacherComponent,
    AssignTeacherComponent
  ],
  imports: [    
    TimepickerModule.forRoot(),
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'AddUser', component: AddUserComponent },
      { path: 'AddRoom', component: AddRoomComponent },
      { path: 'GetUsers', component: GetUsersComponent },
      { path: 'GetRooms', component: GetRoomsComponent },
      { path: 'AddRoomAvailability', component: AddRoomAvailabilityComponent },
      { path: 'GetRoom/:id', component: GetRoomComponent },
      { path: 'UpdateRoom/:id', component: UpdateRoomComponent },
      { path: 'AddReservation', component: AddReservationComponent },
      { path: 'GetReservations', component: GetReservationsComponent },
      { path: 'GetReservation/:id', component: GetReservationComponent },
      { path: 'UpdateReservation/:id', component: UpdateReservationComponent },
      { path: 'GetUser/:id', component: GetUserComponent },
      { path: 'UpdateUser/:id', component: UpdateUserComponent },
      { path: 'AddLecture', component: AddLectureComponent },
      { path: 'GetLectures', component: GetLecturesComponent },
      { path: 'GetLecture/:id', component: GetLectureComponent },
      { path: 'UpdateLecture/:id', component: UpdateLectureComponent },
      { path: 'AddTeacher', component: AddTeacherComponent },
      { path: 'AssignTeacher', component: AssignTeacherComponent },
    ]),
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
