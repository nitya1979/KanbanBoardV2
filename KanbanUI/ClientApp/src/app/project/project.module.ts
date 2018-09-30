import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectRoutingModule } from './project-routing.module';
import{MatCardModule,MatFormFieldModule, MatInputModule, MatDatepickerModule, MatButtonModule} from '@angular/material';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { CoreModule} from '../core/core.module';
import {ProjectListComponent} from './project-list/project-list.component';
import {ProjectDetailComponent } from './project-detail/project-detail.component';

@NgModule({
  imports: [
    CommonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule, 
    ProjectRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatButtonModule,
    CoreModule
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
