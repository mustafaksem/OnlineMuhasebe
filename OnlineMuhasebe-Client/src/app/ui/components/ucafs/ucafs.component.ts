import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { BlankComponent } from '../../../common/component/blank/blank.component';
import { SectionComponent } from '../../../common/component/blank/section/section.component';
import { NavModel } from '../../../common/component/blank/models/nav.model';
import { RouterLink } from '@angular/router';
import { UcafService } from './services/ucaf.service';
import { UcafModel } from './models/ucaf.model';
import { UcafPipe } from './pipes/ucaf.pipe';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-ucafs',
  standalone: true,
  imports: [CommonModule,BlankComponent,SectionComponent,UcafPipe,FormsModule],
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

filterText: string="";

constructor(
  private _ucaf:UcafService
){}

  ngOnInit(): void {
    this.getAll();
  }

getAll(){
  this._ucaf.getAll(res=>{this.ucafs=res.data});
}
}
