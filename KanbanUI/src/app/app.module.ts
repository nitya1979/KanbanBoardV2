import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule} from './app-routing.module';
import { ChartsModule } from 'ng2-charts';
import { DnpModule } from '../dnp/dnp.Module';
import { AccountModule } from './account/account.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ProjectModule } from './project/project.module';

import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FooterComponent } from './footer/footer.component';
import { ContainerComponent } from './container/container.component';
import { DashBoardComponent } from './dash-board/dash-board.component';
import { ProjectOverviewComponent } from './project-overview/project-overview.component';
import { SideBarComponent } from './side-bar/side-bar.component';

import { ProjectService} from './Services/project.service';
import { TaskListComponent } from './task-list/task-list.component';


@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    ChartsModule,
    DnpModule,
    AccountModule,
    NgbModule.forRoot(),
    ProjectModule
  ],

  declarations: [
    AppComponent,
    SideBarComponent,
    NavBarComponent,
    FooterComponent,
    ContainerComponent,
    DashBoardComponent,
    ProjectOverviewComponent,
    TaskListComponent
  ],

  providers: [
    ProjectService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
