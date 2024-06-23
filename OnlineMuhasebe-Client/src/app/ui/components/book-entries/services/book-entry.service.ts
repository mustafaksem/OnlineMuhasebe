import { Injectable } from '@angular/core';
import { GenericHttpService } from '../../../../common/services/generic-http.service';
import { RequestModel } from '../../../../common/models/request.model';
import { PaginationResultModel } from '../../../../common/models/pagination-result.model';
import { BookEntryModel } from '../models/book-entry.model';
import { LoginResponseService } from '../../../../common/services/login-response.service';
import { MessageResponseModel } from '../../../../common/models/message.response.model';
import { ResponseModel } from '../../../../common/models/response.model';
import { mode } from 'crypto-ts';
import { RemoveByIdModel } from '../../../../common/models/remove-by-id.model';

@Injectable({
  providedIn: 'root'
})
export class BookEntryService {

  constructor(
    private _http:GenericHttpService,
    private _loginResponse:LoginResponseService
  ) { }

  getAll(model:RequestModel,callBack:(res:PaginationResultModel<BookEntryModel[]>)=>void){
    model.companyId=this._loginResponse.getLoginResponseModel().company.companyId;
    model.year=this._loginResponse.getLoginResponseModel().year;
    this._http.post<PaginationResultModel<BookEntryModel[]>>("BookEntries/GetAllBookEntry",model,res=>{
      callBack(res);
    })
  }

  create(model:any,callBack:(res:MessageResponseModel)=>void){
    model.companyId=this._loginResponse.getLoginResponseModel().company.companyId;
    this._http.post<MessageResponseModel>("BookEntries/Create",model,res=>{
      callBack(res);
    })
  }

  removeById(model:RemoveByIdModel,callBack:(res:MessageResponseModel)=>void){
    model.companyId=this._loginResponse.getLoginResponseModel().company.companyId;
    this._http.post<MessageResponseModel>("BookEntries/RemoveById",model,res=>{
      callBack(res);
    })
  }

  update(model: BookEntryModel, callBack: (res:MessageResponseModel)=> void){
    model.companyId = this._loginResponse.getLoginResponseModel().company.companyId;
    this._http.post<MessageResponseModel>("BookEntries/Update",model,res=>{
      callBack(res);
    })
  }

}
