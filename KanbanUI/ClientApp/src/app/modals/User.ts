export class UserDetail{
    UserId : string;
    UserName:string;
    PhoneNo:string;
    Email:string;
    
    public constructor(init?:Partial<UserDetail>){
        return Object.assign(this, init);
    }
}
