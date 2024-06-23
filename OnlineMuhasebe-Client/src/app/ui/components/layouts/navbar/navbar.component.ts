import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../auth/services/auth.service';
import { FormsModule } from '@angular/forms';
import { LoginResponseModel } from '../../auth/models/login-response.model';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  @Input() loginResponse: LoginResponseModel = new LoginResponseModel();
  years: number[] = [];

  constructor(
    private _auth: AuthService
  ) {}

  ngOnInit() {
    const currentYear = new Date().getFullYear();
    this.years = [currentYear - 3,currentYear - 2,currentYear - 1, currentYear, currentYear + 1];
  }

  logout() {
    this._auth.logout();
  }

  changeYear() {
    this._auth.changeYear(this.loginResponse);
    window.location.reload();
  }
}