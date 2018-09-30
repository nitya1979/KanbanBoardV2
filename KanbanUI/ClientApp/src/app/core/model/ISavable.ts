
export interface ISavable{

    save():void;
    
    validate():boolean;

    isModified():boolean;
}