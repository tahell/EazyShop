import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { AllProductsComponent } from './component/all-products/all-products.component';
import { CategoryListComponent } from './component/category-list/category-list.component';
import { HomeComponent } from './component/home/home.component';
import { SignInComponent } from './component/sign-in/sign-in.component';
import { SignUpComponent } from './component/sign-up/sign-up.component';

const routes: Routes = [
  {path:'',component:HomeComponent},
    {path:'Home',component:HomeComponent},
    {path:'sign-in',component:SignInComponent},
    {path:'sign-up',component:SignUpComponent},
    {path:'category-list',component:CategoryListComponent},
    {path:'about',component:AboutComponent},
    { path:'all-products', component:AllProductsComponent}
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
