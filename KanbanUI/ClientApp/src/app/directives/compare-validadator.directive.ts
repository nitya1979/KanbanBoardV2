import { Directive } from '@angular/core';
import { Validator, NG_VALIDATORS, AbstractControl, ValidatorFn } from '@angular/forms';
import { Attribute } from '@angular/compiler';

export function compareValidator(compare: string): ValidatorFn {
  return (control: AbstractControl): {[key: string]: any} => {
    let e = control.root.get(compare);
    console.log(e? e.value : null);
    console.log(control.value);
    if( e && e.value != control.value){
      return {'retype': {value: control.value}} ;
    }
    
    return null;
  };
}

@Directive({
  selector: '[compare-with]',
  providers :[{ provide: NG_VALIDATORS, useExisting: CompareValidadatorDirective, multi:true}]
})
export class CompareValidadatorDirective implements Validator {

  constructor(){
    
  }

  validate(c: AbstractControl): { [key: string]: any; } {
    let e = c.root.get('compare-with')
    if( e && c.value != e.value )
      return {'compare':true};

    return null;
  }
  


}
