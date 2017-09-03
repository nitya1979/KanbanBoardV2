import { Injectable } from '@angular/core';

@Injectable()
export class ProjectService {

  constructor() { }

  getAll(){

  return PROJECTS;
  }

}

const PROJECTS = [{
    ID : 1,
    Name : "Project 1",
    Description : "This is discription of Porject 1",
    StartDate : new Date("1/1/2017"),
    EndDate : new Date("3/1/2017"),
    States:[{
        ID : 1,
        Name : "Back Log",
        Order : 1
        },
        { ID : 2,
        Name : "In Progress",
        Order : 2,
        },
        { ID :3,
        Name : "Completed",
        Order : 3
        }]
},{
    ID : 2,
    Name : "Project 2",
    Description : "This is discription of Porject 2",
    StartDate : new Date("1/1/2017"),
    EndDate : new Date("3/1/2017"),
    States:[{
        ID : 4,
        Name : "Back Log",
        Order : 1
        },
        { ID : 5,
        Name : "In Progress",
        Order : 2,
        },
        { ID :6,
        Name : "Completed",
        Order : 3
        }]
},{
    ID : 3,
    Name : "Project 3",
    Description : "This is discription of Porject 3",
    StartDate : new Date("1/1/2017"),
    EndDate : new Date("3/1/2017"),
    States:[{
        ID : 4,
        Name : "Back Log",
        Order : 1
        },
        { ID : 5,
        Name : "In Progress",
        Order : 2,
        },
        { ID :6,
        Name : "Completed",
        Order : 3
        }]
}

]
