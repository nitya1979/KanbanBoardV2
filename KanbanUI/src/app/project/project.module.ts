import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectRoutingModule } from './project-routing.module';

import {ProjectListComponent} from './project-list/project-list.component';
import {ProjectDetailComponent } from './project-detail/project-detail.component';

@NgModule({
  imports: [
    CommonModule,
    ProjectRoutingModule
  ],
  declarations: [
    ProjectDetailComponent,
    ProjectListComponent
  ],

  exports: [
    ProjectDetailComponent
  ]
})
export class ProjectModule { }
