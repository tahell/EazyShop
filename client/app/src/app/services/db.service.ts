import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../model/User';

@Injectable({
  providedIn: 'root'
})
export class DbService {

  constructor(private httpClient:HttpClient) { }
  GetUser(){
    return this.httpClient.get<User[]>("http://localhost:51399/api/User/GetUser")
  }

  





}
