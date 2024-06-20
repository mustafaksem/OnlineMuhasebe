import { Injectable } from '@angular/core';

import { LogRequestModel } from '../models/log-request.model';
import { LogModel } from '../models/log.model';
import {LoginResponseService} from '../../../../common/services/login-response.service'
import { GenericHttpService } from '../../../../common/services/generic-http.service';
import { ResponseModel } from '../../../../common/models/response.model';
import { PaginationResultModel } from '../../../../common/models/pagination-result.model';


@Injectable({
  providedIn: 'root'
})
export class LogService {

  constructor(
    private _http: GenericHttpService,
    private _loginResponse: LoginResponseService
  ) { }

  getAllByTableName(model: LogRequestModel , callBack: (res: ResponseModel<PaginationResultModel<LogModel[]>>) => void){
    model.companyId = this._loginResponse.getLoginResponseModel().company.companyId;
    this._http.post<ResponseModel<PaginationResultModel<LogModel[]>>>("Logs/GetLogsByTableName",model, res=>{
      callBack(res);
    });
  }
}