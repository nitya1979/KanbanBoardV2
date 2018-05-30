import { TestBed, inject } from '@angular/core/testing';
import {HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { AccountService } from './account.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { defer } from 'rxjs/observable/defer';


export function asyncData<T>(data: T) {
  return defer(() => Promise.resolve(data));
}

describe('AccountService', () => {
   let httpClientSpy : {get : jasmine.Spy};
   let accountService : AccountService;

    beforeEach(() => {
    //TestBed.configureTestingModule({
    //  providers: [AccountService]
    //});
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);
    accountService = new AccountService(<any> httpClientSpy );

    //TestBed.get(AccountService)
  });

  //it('should be created', inject([AccountService], (service: AccountService) => {
  //  expect(service).toBeTruthy();
  //}));

  it('should find valid user', ()=>{
    const expectedResult = ["nityaprakash.sharma@gmail.com already exists."];

    httpClientSpy.get.and.throwError( new error( expectedResult));
    accountService.validateEmail("nityaprakash.sharma@gmail.com").subscribe(
      data => expect(data).toEqual(expectedResult, 'expected result'),
      fail
    )
  });
});
