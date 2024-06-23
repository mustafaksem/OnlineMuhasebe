import { CommonModule, DatePipe, NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { BlankComponent } from '../../../common/component/blank/blank.component';
import { SectionComponent } from '../../../common/component/blank/section/section.component';
import { NavModel } from '../../../common/component/blank/models/nav.model';
import { ExcelLoadingButtonComponent } from '../../../common/component/excel-loading-button/excel-loading-button.component';
import { FormsModule, NgForm } from '@angular/forms';
import { PaginationResultModel } from '../../../common/models/pagination-result.model';
import { BookEntryModel } from './models/book-entry.model';
import { BookEntryService } from './services/book-entry.service';
import { RequestModel } from '../../../common/models/request.model';
import { ValidInputDirective } from '../../../common/directives/valid-input.directive';
import { LoadingButtonComponent } from '../../../common/component/loading-button/loading-button.component';
import { CreateBookEntryModel } from './models/create-book-entry.model';
import { ToastrService, ToastrType } from '../../../common/services/toastr.service';
import { LoginResponseModel } from '../auth/models/login-response.model';
import { LoginResponseService } from '../../../common/services/login-response.service';
import { RemoveByIdModel } from '../../../common/models/remove-by-id.model';
import { SwalService } from '../../../common/services/swal.service';
import { ReportRequestModel } from '../../../common/models/report-request.model';
import { ReportService } from '../reports/services/report.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-book-entries',
  standalone: true,
  imports: [CommonModule,BlankComponent,SectionComponent,ExcelLoadingButtonComponent,FormsModule,ValidInputDirective,LoadingButtonComponent],
  templateUrl: './book-entries.component.html',
  styleUrl: './book-entries.component.css'
})
export class BookEntriesComponent implements OnInit {
  navs:NavModel[]=[
    {
    routerLink:"/",
    class:"",
    name:"Ana Sayfa"
  },
  {
    routerLink:"/book-entries",
    class:"activate",
    name:"Yevmiye Fişleri"
  }
  ]

  filterText:string="";
  pageNumber:number=1;
  pageNumbers:number[]=[];
  dateInput:string="";
  typeSelect:string="Muavin";
  pageSize:number=5;
  updateModel:BookEntryModel= new BookEntryModel();
  result :PaginationResultModel<BookEntryModel[]>= new PaginationResultModel<BookEntryModel[]>();

  constructor(
    private _bookEntry:BookEntryService,
    private _date:DatePipe,
    private _toastr:ToastrService,
    private _loginResponse: LoginResponseService,
    private _swal:SwalService,
    private __report:ReportService,
    private _router:Router
  ){ 
    this.dateInput=_date.transform(new Date(),"yyyy-MM-dd")
   }

  ngOnInit(): void {
    this.getAll();
  }

  getAll(pageNumber:number=1){
    this.pageNumber=pageNumber;
    let model:RequestModel =new RequestModel();
    model.pageNumber=this.pageNumber;
    model.pageSize=this.pageSize;

    this._bookEntry.getAll(model,res=>{
      this.result=res;   
      this.pageNumbers=[];  
      for(let i=0; i<res.totalPages;i++){
        this.pageNumbers.push(i+1);
      }
    });
  }

  create(form: NgForm){
    if(form.valid){
      let model:CreateBookEntryModel=new CreateBookEntryModel();
      model.date=form.controls["date"].value;
      model.type=form.controls["type"].value;
      model.description=form.controls["description"].value;

      debugger;
      let year=this.dateInput.split("-")[0];
      if(this._loginResponse.getLoginResponseModel().year != +year){
        this._toastr.toast(ToastrType.Error,"Sadece seçili yıl için işlem yapabilirsiniz.");
        return;
      }

      this._bookEntry.create(model,(res)=>{
        this._toastr.toast(ToastrType.Success,res.message,"");
        form.controls["description"].setValue("");
        this.dateInput=this._date.transform(new Date(),"yyyy-MM-dd");
        this.typeSelect="Muavin";
        this.getAll();
        let element =document.getElementById("createModelCloseBtn");
        element.click();
      })
    }
  }

  getUpdateModel(model: BookEntryModel){
    this.updateModel = {...model};
    this.updateModel.date = this._date.transform(model.date,'yyyy-MM-dd');
  }

  update(form: NgForm){
    if(form.valid){
      let year = this.updateModel.date.split("-")[0];
      if(this._loginResponse.getLoginResponseModel().year != +year){
        this._toastr.toast(ToastrType.Error,"Sadece seçili yıla işlem yapabilirsiniz!");
        return;
      }

      this._bookEntry.update(this.updateModel,(res)=>{
        this._toastr.toast(ToastrType.Warning,res.message,"");                
        this.getAll();
        let element = document.getElementById("updateModelCloseBtn");
        element.click();
      });
    }
  }

  changeBlankTrClass(model: BookEntryModel){
    if(model.debit +model.credit ==0)
      return "text-danger"

    return ""
  }

  removeById(bookEntry: BookEntryModel){
    this._swal.callSwal("Sil?","Yevmiye Fişi Sil?",`${bookEntry.bookEntryNumber} numaralı Yevmiye Fişini silmek istiyor musunuz?`, ()=>{
      let model: RemoveByIdModel = new RemoveByIdModel();
      model.id = bookEntry.id;

      this._bookEntry.removeById(model,res=>{
        this._toastr.toast(ToastrType.Info,res.message,"");
        this.getAll(this.pageNumber);
      });
    })
  }

  exportExcel(){
    let model:ReportRequestModel =new ReportRequestModel();
    model.name="Yevmiye Fişleri";

    this.__report.request(model,(res)=>{
      this._toastr.toast(ToastrType.Info,res.message);
      this._router.navigateByUrl("/reports");
    })
  }

}
