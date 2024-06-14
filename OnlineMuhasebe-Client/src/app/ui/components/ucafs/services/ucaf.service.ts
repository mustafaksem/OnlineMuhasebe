import { Injectable } from '@angular/core';

import { GenericHttpService } from '../../../../common/services/generic-http.service';
import { UcafModel } from '../models/ucaf.model';
import { LoginResponseModel } from '../../auth/models/login-response.model';
import { CyrptoService } from '../../../../common/services/crypto.service';
import { ResponseModel } from '../../../../common/models/response.model';
import { MessageResponseModel } from '../../../../common/models/message.response.model';
import { RemoveByIdUcafModel } from '../models/remove-by-id-ucaf.model';
import { mode } from 'crypto-ts';

@Injectable({
  providedIn: 'root'
})


export class UcafService {

  loginResponse: LoginResponseModel = new LoginResponseModel();
  constructor(
    private _crypto: CyrptoService,
    private _http:GenericHttpService
  ){
    let loginResponseString = _crypto.decrypto(localStorage.getItem("accessToken").toString());    
    this.loginResponse = JSON.parse(loginResponseString);
  }

  getAll(callBack: (res:ResponseModel<UcafModel[]>)=> void){    
    let model = {companyId:this.loginResponse.company.companyId};
    this._http.post<ResponseModel<UcafModel[]>>("UCAFs/GetAllUCAF",model,res=> callBack(res));
  }

  add(model:UcafModel,callBack:(res: MessageResponseModel)=>void){
    model.companyId=this.loginResponse.company.companyId;
    this._http.post<MessageResponseModel>("UCAFs/CreateUCAF",model,(res)=>callBack(res));
  }

  removeById(model:RemoveByIdUcafModel,callBack: (res:MessageResponseModel)=>void){
    model.companyId=this.loginResponse.company.companyId;
    this._http.post<MessageResponseModel>("UCAFs/RemoveByIdUCAF",model,(res)=>callBack(res));
  }

}
