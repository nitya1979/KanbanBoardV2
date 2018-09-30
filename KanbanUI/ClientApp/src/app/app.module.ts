import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule} from './app-routing.module';
import { CoreModule } from './core/core.module';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {LayoutModule} from '@angular/cdk/layout'; 
import {MatMenuModule, MatButtonModule, MatIconModule, MatCardModule , MatToolbarModule, MatSidenavModule,
MatListModule, MatFormFieldModule, MatDatepickerModule,MatNativeDateModule, MatCheckboxModule, MatTableModule, MatDialog, MatDialogModule} from '@angular/material';
import {GravatarModule} from 'ngx-gravatar';

import { ChartsModule } from 'ng2-charts';
import { AccountModule } from './account/account.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ProjectModule } from './project/project.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { KanbanHttpInterceptor } from './kanban-http-interceptor';
import {AuthGaurdService} from './auth-gaurd.service';
import {AccountService} from './Services/account.service';

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
import { CompareValidadatorDirective } from './directives/compare-validadator.directive';
import { KanbanService } from './Services/kanban.service';





@NgModule({
  imports: [
    BrowserModule,
     BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule,
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
    MatCheckboxModule,
    MatTableModule,
    MatDialogModule,
    ChartsModule,
    AccountModule,
    NgbModule.forRoot(),
    ProjectModule,
    LayoutModule,
    GravatarModule
  ],

  declarations: [
    AppComponent,
    SideBarComponent,
    NavBarComponent,
    FooterComponent,
    ContainerComponent,
    DashBoardComponent,
    ProjectOverviewComponent,
    TaskListComponent,
    CompareValidadatorDirective
  ],

  providers: [
    KanbanService,
    AuthGaurdService,
    ProjectService,
    { 
      provide: HTTP_INTERCEPTORS, 
      useClass: KanbanHttpInterceptor,
      multi: true
    } , 
    AuthenticationService,
    AccountService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
