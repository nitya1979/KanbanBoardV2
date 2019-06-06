import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectRoutingModule } from './project-routing.module';
import{MatCardModule,MatFormFieldModule, MatInputModule, MatSelectModule, MatIconModule, MatOptionModule, MatDatepickerModule, MatAutocompleteModule, MatButtonModule} from '@angular/material';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { CoreModule} from '../core/core.module';
import {ProjectListComponent} from './project-list/project-list.component';
import {ProjectDetailComponent } from './project-detail/project-detail.component';
import { TaskComponent } from './task/task.component';

@NgModule({
  imports: [
    CommonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule, 
    MatSelectModule,
    MatOptionModule,
    ProjectRoutingModule,
    FormsModule,
    MatIconModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatButtonModule,
    MatAutocompleteModule,
    CoreModule
  ],
  declarations: [ 
    ProjectDetailComponent,
    ProjectListComponent,
    TaskComponent
  ],

  exports: [
    ProjectDetailComponent
  ]
})
export class ProjectModule { }
