import { Component, OnInit, Input, Output } from '@angular/core';

@Component({
  selector: 'dnp-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css']
})
export class GridComponent implements OnInit {
  @Input() rows:any;
  @Input() columns:any;
  @Input() page:number;
  @Input() pagesize:number;

  constructor() { }

  ngOnInit() {
    
  }

  public getData(row:any, propertyName:string):string {
   
   return propertyName.split('.').reduce((prev:any, curr:string) => prev[curr], row);

  }

  get RowData(){
    return JSON.stringify(this.rows);
  }
}
