import { Component, OnInit } from '@angular/core';
import{ FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  EditMode:boolean = false;
  UserName:string = "Nitya Prakash Sharma";
  constructor() { }

  ngOnInit() {
  }

}
