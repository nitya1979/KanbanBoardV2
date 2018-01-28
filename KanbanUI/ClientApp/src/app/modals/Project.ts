export class TaskStates{
    ID : number;
    Name: string;
    Order : number;
}

export class Project{
    ID : number;
    Name : string;
    Description: string;
    StartDate : Date;
    EndDate : Date;
    Completion: Date;
    States : TaskStates[];  
}
