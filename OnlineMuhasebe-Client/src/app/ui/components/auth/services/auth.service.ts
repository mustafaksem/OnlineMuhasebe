import { Injectable } from '@angular/core';
import { GenericHttpService } from '../../../../common/services/generic-http.service';
import { LoginResponseModel } from '../models/login-response.model';
import { Router } from '@angular/router';
import { CyrptoService } from '../../../../common/services/crypto.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  api:string="Auth/Login";
  constructor(
    private _http:GenericHttpService,
    private _router:Router,
    private _cyrpto:CyrptoService
  ) { }

  login(model:any){
    this._http.post<LoginResponseModel>(this.api,model,res=>{
      let cryptoValue =this._cyrpto.encrypto(JSON.stringify(res))
      localStorage.setItem("accessToken",cryptoValue);
      this._router.navigateByUrl("/");
    })
  }

  logout(){
    localStorage.removeItem("accessToken");
    this._router.navigateByUrl("/login");
  }
}