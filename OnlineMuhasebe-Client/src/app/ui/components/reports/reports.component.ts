import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { BlankComponent } from '../../../common/component/blank/blank.component';
import { SectionComponent } from '../../../common/component/blank/section/section.component';
import { NavModel } from '../../../common/component/blank/models/nav.model';
import { ReportModel } from './models/report.model';
import { ReportService } from './services/report.service';
import { PaginationResultModel } from '../../../common/models/pagination-result.model';


@Component({
  selector: 'app-reports',
  standalone: true,
  imports: [CommonModule,BlankComponent,SectionComponent],
  templateUrl: './reports.component.html',
  styleUrl: './reports.component.css'
})
export class ReportsComponent implements OnInit,OnDestroy {
  navs:NavModel[]=[
    {
    routerLink:"/",
    class:"",
    name:"Ana Sayfa"
  },
  {
    routerLink:"/reports",
    class:"activate",
    name:"Raporlar"
  }
  ]

  result: PaginationResultModel<ReportModel[]> = new PaginationResultModel<ReportModel[]>;

  pageNumber:number=1;
  pageSize:number=5;
  pageNumbers:number[]=[];

  count :number=0;
  interval:any;

  constructor(
    private _report:ReportService
  ){ }
  ngOnDestroy(): void {
    clearInterval(this.interval);
  }

  ngOnInit(){
    this.getAll();
    this.interval=setInterval(()=>{
      if(this.count<25){
        this.count++;
        this.getAll(this.pageNumber);
      }else{
        clearInterval(this.interval);
      }
    },5000)
  }

  getAll(pageNumber:number=1){
    this.pageNumber=pageNumber;
    this._report.getAll(this.pageNumber,this.pageSize,res=>{
      this.result=res;
      this.pageNumbers=[];
      for(let i=0; i<res.totalPages;i++){
        this.pageNumbers.push(i+1);
      }
    });
  }

  changeSpanClassByStatus(status:boolean){
    if(status)  
       return "text-success";

    return "text-danger";
  }

}
