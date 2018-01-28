import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes} from '@angular/router';

import {ProjectListComponent} from './project-list/project-list.component';
import { ProjectDetailComponent} from './project-detail/project-detail.component';

const projectRoutes: Routes = [
    {
        path : 'projectlist',
        component : ProjectListComponent
    },
    {
        path : 'projectdetail',
        component : ProjectDetailComponent
    },
    {
        path : '',
        redirectTo: 'projectlist', pathMatch : 'full'
    }
];

@NgModule({
imports: [
    RouterModule.forChild(projectRoutes)
],

declarations: [],

exports: [
    RouterModule
]
})

export class ProjectRoutingModule { }