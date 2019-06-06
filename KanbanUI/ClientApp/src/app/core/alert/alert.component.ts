import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { DnpResult } from '../model/ActionResult';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css']
})
export class AlertComponent implements OnInit {
  @Input() showTime:number = 10;//show alert only for 10 second
  @Input() result:DnpResult;

  showAlert:boolean = true;

  constructor() { }

  ngOnChanges(){
    this.showAlert = true;
    setTimeout( ()=>{
      this.showAlert = false;
      
    }, this.showTime*1000);
  }
  ngOnInit() {
    this.result = new DnpResult({
      Messages: new Array()
    });
    console.log(this.result.toString());
  }

}
