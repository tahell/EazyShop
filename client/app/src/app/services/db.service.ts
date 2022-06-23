import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../model/User';
import { Observable } from 'rxjs';
import { Signup } from '../model/Sign-Up';
import { Signin } from '../model/Sign-in'
import { Category } from '../model/Category';
import { Product } from '../model/Product';


@Injectable({
  providedIn: 'root'
})
export class DbService {

  public allProductsForCategory: Product[] = []
  public allProducts: Product[] = []
  public myPath: any[] = []
  constructor(private httpClient: HttpClient) { }
  SignIn(signup: Signup): Observable<Signin> {
    return this.httpClient.post<Signin>("http://localhost:51399/api/user/RegisterUser", signup)
  }

  SignUp(signIn: Signin): Observable<Signin> {
    return this.httpClient.post<Signin>("http://localhost:51399/api/User/LoginUser", signIn)
  }

  getAllProducts(CatClass: number) {
    return this.httpClient.get<Product[]>("http://localhost:51399/api/Department/GetDepartmentAccordingCode/" + CatClass)
  }
  getAllCategories() {
    return this.httpClient.get<Category[]>("http://localhost:51399/api/Department/GetAllDepartments")
  }


  calcPathToProduct(): Observable<any[]> {
    let data = new FormData();
    let val = JSON.stringify(this.allProducts);
    console.log(val)
    data.append('allProducts', val)
    return this.httpClient.post<any[]>("http://localhost:51399/api/Products/GetNodes", data)

  }
}
