﻿import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes} from '@angular/router';
import {AuthGaurdService} from '../auth-gaurd.service';

import {ProjectListComponent} from './project-list/project-list.component';
import { ProjectDetailComponent} from './project-detail/project-detail.component';

const projectRoutes: Routes = [
    {
        path : 'projectlist',
        component : ProjectListComponent,
        canActivate : [AuthGaurdService]
    },
    {
        path : 'projectdetail',
        component : ProjectDetailComponent,
        canActivate : [AuthGaurdService]
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