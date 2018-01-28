import { NgModule } from '@angular/core';
import { RouterModule, Routes} from '@angular/router';
import { DashBoardComponent } from './dash-board/dash-board.component';


const routes: Routes = [
    {path : 'dashboard',
    component : DashBoardComponent
    },
     {path : '', redirectTo : '/dashboard', pathMatch: 'full'},
     {path : 'account', loadChildren:'app/account/account.module#AccountModule'},
     {
        path : 'projects',
        loadChildren : 'app/project/project.module#ProjectModule'
     }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],

  declarations:[],

  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
