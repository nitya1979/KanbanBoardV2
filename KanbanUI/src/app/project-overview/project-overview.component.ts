import { Component, OnInit,Input, Output,EventEmitter } from '@angular/core';
import {Project, TaskStates} from '../modals/Project'

@Component({
  selector: 'app-project-overview',
  templateUrl: './project-overview.component.html',
  styleUrls: ['./project-overview.component.css']
})
export class ProjectOverviewComponent implements OnInit {
  @Input() project:any;

  doughnutChartLabels:string[] = ['Back Log', 'In Progress', 'Completed'];
  doughnutChartData:number[] = [350, 450, 100];
  doughnutChartType:string = 'doughnut';
  doughnutChartColor = ['rgb(255,0,0)', "rgb(0,255,0)","rgb(0,0,255)"];
  options:any = { legend:{display:false}};



  constructor() { }


  ngOnInit() {
  }

  // events
  public chartClicked(e:any):void {
    console.log(e);
  }
 
  public chartHovered(e:any):void {
    console.log(e);
  }

 

}
