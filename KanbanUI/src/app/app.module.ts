import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule} from './app-routing.module';
import { ChartsModule } from 'ng2-charts';
import { DnpModule } from '../dnp/dnp.Module';

import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FooterComponent } from './footer/footer.component';
import { ContainerComponent } from './container/container.component';
import { DashBoardComponent } from './dash-board/dash-board.component';
import { ProjectOverviewComponent } from './project-overview/project-overview.component';

import { ProjectService} from './Services/project.service';
import { TaskListComponent } from './task-list/task-list.component';


@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    ChartsModule,
    DnpModule
  ],

  declarations: [
    AppComponent,
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
