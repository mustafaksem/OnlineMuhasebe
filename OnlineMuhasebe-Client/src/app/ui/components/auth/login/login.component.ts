import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ValidInputDirective } from '../../../../common/directives/valid-input.directive';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,RouterModule, FormsModule,ValidInputDirective],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  login(form:NgForm){
    if(form.valid){
      console.log(form.value)
    }
  }
}
