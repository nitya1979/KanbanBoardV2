import { TestBed, inject } from '@angular/core/testing';
import {HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { AccountService } from './account.service';
import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { defer } from 'rxjs/observable/defer';
import { Jsonp } from '../../../node_modules/@angular/http/src/http';


export function asyncData<T>(data: T) {
  return defer(() => Promise.resolve(data));
}

describe('AccountService', () => {
   let httpClientSpy : {get : jasmine.Spy};
   let accountService : AccountService;

    beforeEach(() => {
      httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);
      accountService = new AccountService(<any> httpClientSpy );
  });

  //it('should be created', inject([AccountService], (service: AccountService) => {
  //  expect(service).toBeTruthy();
  //}));

  it('should email already exists', ()=>{
    const expectedResult = ["nityaprakash.sharma@gmail.com already exists."];

    const errorResponse = new HttpErrorResponse({
      error: JSON.stringify( expectedResult),
      status: 400, statusText: 'Bad Request'
    });
    httpClientSpy.get.and.returnValue( Observable.of( errorResponse));
    accountService.validateEmail("nityaprakash.sharma@gmail.com").subscribe(
      data => expect(data.error).toEqual(JSON.stringify( expectedResult), 'expected result')
    )
  });

  it('should email not alread exists', ()=>{
    const expectedResult = '';

    const response = new HttpResponse({
      body: ''   });
    httpClientSpy.get.and.returnValue( Observable.of( response));
    accountService.validateEmail("nityaprakash.sharma@gmail.com").subscribe(
      data => expect(data.body).toEqual( expectedResult, 'expected result')
    )
  });

  it('should UserName already exists', ()=>{
    const expectedResult = ["nitsharm already exists."];

    const errorResponse = new HttpErrorResponse({
      error: JSON.stringify( expectedResult),
      status: 400, statusText: 'Bad Request'
    });
    httpClientSpy.get.and.returnValue( Observable.of( errorResponse));
    accountService.validateUser("nitsharm").subscribe(
      data => expect(data.error).toEqual(JSON.stringify( expectedResult), 'expected result')
    )
  });

  it('should UserName not alread exists', ()=>{
    const expectedResult = '';

    const response = new HttpResponse({
      body: ''   });
    httpClientSpy.get.and.returnValue( Observable.of( response));
    accountService.validateUser("nitsharm").subscribe(
      data => expect(data.body).toEqual( expectedResult, 'expected result')
    )
  });
});
