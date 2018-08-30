export class DnpResult
{
    Success : boolean;
    Messages : string[];

    public constructor(init?:Partial<DnpResult>){
        return Object.assign(this, init);
    }
}