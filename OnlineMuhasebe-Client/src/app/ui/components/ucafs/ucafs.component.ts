import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { BlankComponent } from '../../../common/component/blank/blank.component';
import { SectionComponent } from '../../../common/component/blank/section/section.component';
import { NavModel } from '../../../common/component/blank/models/nav.model';
import { UcafService } from './services/ucaf.service';
import { UcafModel } from './models/ucaf.model';
import { UcafPipe } from './pipes/ucaf.pipe';
import { FormsModule, NgForm } from '@angular/forms';
import { ValidInputDirective } from '../../../common/directives/valid-input.directive';
import { ToastrService, ToastrType } from '../../../common/services/toastr.service';
import { LoadingButtonComponent } from '../../../common/component/loading-button/loading-button.component';
import { SwalService } from '../../../common/services/swal.service';
import { ExcelLoadingButtonComponent } from '../../../common/component/excel-loading-button/excel-loading-button.component';
import { ReportRequestModel } from '../../../common/models/report-request.model';
import { ReportService } from '../reports/services/report.service';
import { Router } from '@angular/router';
import { RemoveByIdModel } from '../../../common/models/remove-by-id.model';

@Component({
  selector: 'app-ucafs',
  standalone: true,
  imports: [CommonModule,
    BlankComponent,
    SectionComponent,
    UcafPipe,
    FormsModule,
    ValidInputDirective,
    FormsModule,
    LoadingButtonComponent,
  ExcelLoadingButtonComponent],
  templateUrl: './ucafs.component.html',
  styleUrl: './ucafs.component.css'
})
export class UcafsComponent implements OnInit {
navs:NavModel[]=[
  {
  routerLink:"/",
  class:"",
  name:"Ana Sayfa"
},
{
  routerLink:"/ucafs",
  class:"activate",
  name:"Hesap Planı"
}
]

ucafs:UcafModel[]=[];
updateModel: UcafModel=new UcafModel();
ucafType:string="M";
filterText: string="";

isLoading: boolean = false;

isAddForm:boolean=false;
isUpdateForm: boolean=false;

constructor(
  private _ucaf:UcafService,
  private _toastr:ToastrService,
  private _swal:SwalService,
  private _report:ReportService,
  private _router:Router
){}

  ngOnInit(): void {
    this.getAll();
  }

  getAll(){
    this._ucaf.getAll(res=>{this.ucafs=res.data});
  }

  showAddForm(){
    this.isAddForm=true;
  }
  add(form:NgForm){
    if(form.valid){
      let model=new UcafModel();
      model.code=form.controls["code"].value;
      model.type=form.controls["type"].value;
      model.name=form.controls["name"].value;

      this._ucaf.add(model,(res)=>{
        form.controls["code"].setValue("");
        form.controls["name"].setValue("");
        this.ucafType="M";

        this.getAll();
        this._toastr.toast(ToastrType.Success,res.message,"Başarılı");
      });
    }
  }
  
  get(model: UcafModel){
    this.updateModel={...model};
    this.isUpdateForm=true;
    this.isAddForm=false;
  }

  update(form:NgForm){
    if(form.valid){
      this._ucaf.update(this.updateModel, (res) => {        
        this.cancel();
        this.getAll();        
        this._toastr.toast(ToastrType.Info, res.message, "Başarılı!");
      });
    }
}

  cancel(){
    this.isAddForm=false;
    this.isUpdateForm=false;
  }

  removeById(id:string){

    this._swal.callSwal("Sil","Sil?","Hesap planı kodunu silmek istiyor musunuz?",()=>{
      let model=new RemoveByIdModel();
      model.id=id;

      this._ucaf.removeById(model,res=>{
        this.getAll();
        this._toastr.toast(ToastrType.Info,res.message,"Silme Başarılı.");
      });
    });
  }

  setTrClass(type:string){
    if(type=="A")
      return "";
    else if(type=="G")
      return "text-primary";
    else
      return "text-danger";
  }  
  
  exportExcel(){
    let model:ReportRequestModel =new ReportRequestModel();
    model.name="Hesap Planı";

    this._report.request(model,(res)=>{
      this._toastr.toast(ToastrType.Info,res.message);
      this._router.navigateByUrl("/reports");
    })
  }

}
