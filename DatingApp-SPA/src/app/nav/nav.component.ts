import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {}; // pusty obiekt typu any

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  // metoda login
  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('Logged in successfully');
    }, error => {
      console.log(error);
    });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token; // true jesli w zmiennej token cos jest, jak zmienna token jest pusta to zwroci false
  }

  logout() {
    localStorage.removeItem('token');
    console.log('logged out');
  }

}
