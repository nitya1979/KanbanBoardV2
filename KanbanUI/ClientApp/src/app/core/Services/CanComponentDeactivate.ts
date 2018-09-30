import { Injectable } from "@angular/core";
import { CanDeactivate } from "@angular/router";
import { ISavable } from "../model/ISavable";

@Injectable()
export class CanComponentDeactivate implements CanDeactivate<ISavable>{

    canDeactivate(component: ISavable){
        
        return component.isModified();
    }
}