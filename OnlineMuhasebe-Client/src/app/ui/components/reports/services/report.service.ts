import { Injectable } from '@angular/core';
import { GenericHttpService } from '../../../../common/services/generic-http.service';
import { ResponseModel } from '../../../../common/models/response.model';
import { ReportModel } from '../models/report.model';
import { LoginResponseService } from '../../../../common/services/login-response.service';
import { RequestModel } from '../../../../common/models/request.model';
import { mode } from 'crypto-ts';
import { ReportRequestModel } from '../../../../common/models/report-request.model';
import { MessageResponseModel } from '../../../../common/models/message.response.model';

@Injectable({
  providedIn: 'root'
})
export class ReportService {


  constructor(
    private _http:GenericHttpService,
    private _loginResponse:LoginResponseService
  ) { }

  getAll(callBack: (res:ReportModel[])=>void){
    let model:RequestModel =new RequestModel();
    model.companyId=this._loginResponse.getLoginResponseModel().company.companyId;
    this._http.post<ResponseModel<ReportModel[]>>("Reports/GetAll",model,res=>{
      callBack(res.data);
    })
  }

  request(model:ReportRequestModel,callBack: (res:MessageResponseModel)=>void){
    model.companyId =this._loginResponse.getLoginResponseModel().company.companyId;
    this._http.post<MessageResponseModel>("Reports/RequestReport",model,res=>{
      callBack(res);
    })
  }
}
