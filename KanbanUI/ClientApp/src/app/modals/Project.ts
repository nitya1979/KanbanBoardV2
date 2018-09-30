export class TaskStates{
    ID : number;
    Name: string;
    Order : number;
}

export class Project{
    ProjectID : number;
    ProjectName : string;
    Description: string;
    StartDate : Date;
    DueDate : Date;
    Completion: Date;
    States : TaskStates[];  

    public constructor(init?:Partial<Project>){
        Object.assign(this,init);
    }
}
