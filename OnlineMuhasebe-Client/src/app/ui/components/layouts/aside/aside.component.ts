import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import {  RouterModule } from '@angular/router';

import { LoginResponseModel } from '../../auth/models/login-response.model';
import { Navigations } from '../../../router/navigation';
import { AuthService } from '../../auth/services/auth.service';

@Component({
  selector: 'app-aside',
  standalone: true,
  imports: [CommonModule,RouterModule],
  templateUrl: './aside.component.html',
  styleUrl: './aside.component.css'
})
export class AsideComponent {
  @Input() loginResponse: LoginResponseModel = new LoginResponseModel();
  navigations=Navigations;
}
