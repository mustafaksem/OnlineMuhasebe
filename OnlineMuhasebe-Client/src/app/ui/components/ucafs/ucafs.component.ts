import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { BlankComponent } from '../../../common/component/blank/blank.component';
import { SectionComponent } from '../../../common/component/blank/section/section.component';
import { NavModel } from '../../../common/component/blank/models/nav.model';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-ucafs',
  standalone: true,
  imports: [CommonModule,BlankComponent,SectionComponent],
  templateUrl: './ucafs.component.html',
  styleUrl: './ucafs.component.css'
})
export class UcafsComponent {
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


}
