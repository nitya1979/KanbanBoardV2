import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule} from './app-routing.module';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatMenuModule, MatButtonModule, MatIconModule, MatCardModule , MatToolbarModule, MatSidenavModule,
MatListModule, MatFormFieldModule, MatDatepickerModule,MatNativeDateModule} from '@angular/material';

import { ChartsModule } from 'ng2-charts';
import { DnpModule } from '../dnp/dnp.Module';
import { AccountModule } from './account/account.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ProjectModule } from './project/project.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { KanbanHttpInterceptor } from './kanban-http-interceptor';
import {AuthGaurdService} from './auth-gaurd.service';

import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FooterComponent } from './footer/footer.component';
import { ContainerComponent } from './container/container.component';
import { DashBoardComponent } from './dash-board/dash-board.component';
import { ProjectOverviewComponent } from './project-overview/project-overview.component';
import { SideBarComponent } from './side-bar/side-bar.component';

import { ProjectService} from './Services/project.service';
import { TaskListComponent } from './task-list/task-list.component';
import { AuthenticationService } from './Services/authentication.service';
import { from } from 'rxjs/observable/from';
import { httpFactory } from '@angular/http/src/http_module';


@NgModule({
  imports: [
    BrowserModule,
     BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    MatMenuModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatDatepickerModule,
    MatNativeDateModule,
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
    AuthGaurdService,
    ProjectService,
    { 
      provide: HTTP_INTERCEPTORS, 
      useClass: KanbanHttpInterceptor,
      multi: true
    } , 
    AuthenticationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
