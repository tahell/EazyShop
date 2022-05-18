import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../model/User';
import { Observable } from 'rxjs';
import { Signup } from '../model/Sign-Up';
import { Signin } from '../model/Sign-in'
import { Category } from '../model/Category';


@Injectable({
  providedIn: 'root'
})
export class DbService {

  constructor(private httpClient: HttpClient) { }
  Sign(sign: Signin): Observable<Signin> {
    return this.httpClient.post<Signin>("http://localhost:51399/api/user/RegisterUser", sign)
  }


  Signu(Signu: Signup): Observable<Signup> {
    return this.httpClient.post<Signup>("http://localhost:51399/api/User/LoginUser", Signu)
  }
getAllProducts(CatClass:number){
  
    return this.httpClient.post<Category[]>("http://localhost:51399/api/Surgery/GetDepartmentAccordingCode",CatClass)
 
}





}
