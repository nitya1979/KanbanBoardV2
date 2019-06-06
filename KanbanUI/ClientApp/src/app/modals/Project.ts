export class ProjectStage{
    StageID : number;
    StageName: string;
    ProjectID : number;
    Order : number;
}

export class Project{
    ProjectID : number;
    ProjectName : string;
    Description: string;
    Quadrant:boolean;
    StartDate : Date;
    DueDate : Date;
    Completion: Date;
    Stage : ProjectStage[];  

    public constructor(init?:Partial<Project>){
        Object.assign(this,init);
    }
}

export class Priority{
    PriorityID : number;
    PriorityName : string;
}

export class ProjectTask{
    TaskID : number = 0;
    Summary : string = "";
    Description: string = "";
    PriorityID:number = 0;
    StageID : number = 0;
    DueDate : Date = null;
    CompletionDate : Date = null;

    public constructor(init?:Partial<ProjectTask>){
        Object.assign(this, init);
    }
}
