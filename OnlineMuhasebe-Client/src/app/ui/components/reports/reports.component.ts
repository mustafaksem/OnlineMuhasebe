import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { BlankComponent } from '../../../common/component/blank/blank.component';
import { SectionComponent } from '../../../common/component/blank/section/section.component';
import { NavModel } from '../../../common/component/blank/models/nav.model';
import { ReportModel } from './models/report.model';
import { ReportService } from './services/report.service';


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

  reports:ReportModel[]=[];

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
      if(this.count<5){
        this.count++;
        this.getAll();
      }else{
        clearInterval(this.interval);
      }
    },5000)
  }

  getAll(){
    this._report.getAll(res=> this.reports=res);
  }

  changeSpanClassByStatus(status:boolean){
    if(status)  
       return "text-success";

    return "text-danger";
  }

}
