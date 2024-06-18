import { Injectable } from '@angular/core';
import { LoginResponseModel } from '../../ui/components/auth/models/login-response.model';
import { CyrptoService } from './crypto.service';


@Injectable({
  providedIn: 'root'
})
export class LoginResponseService {

  loginResponse: LoginResponseModel = new LoginResponseModel();
  constructor(
    private _cyrpto: CyrptoService,    
  ){}

  getLoginResponseModel(){
    let token = localStorage.getItem("accessToken")?.toString();
    if(token != undefined){
      let loginResponseString = this._cyrpto.decrypto(token);    
      this.loginResponse = JSON.parse(loginResponseString);
    } 
    return this.loginResponse;
  }
}