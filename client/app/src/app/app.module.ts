import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import{HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignInComponent } from './component/sign-in/sign-in.component';
import { SignUpComponent } from './component/sign-up/sign-up.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NavComponent } from './component/nav/nav.component';
import { CategoryListComponent } from './component/category-list/category-list.component';
import { HomeComponent } from './component/home/home.component';
import { AboutComponent } from './about/about.component';
import { AllProductsComponent } from './component/all-products/all-products.component';
import { ProductComponent } from './component/product/product.component';
import { RouterModule } from '@angular/router';

import { TrackComponent } from './component/track/track.component';
import { ListComponent } from './component/list/list.component';
import { DbService } from './services/db.service';

@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
    SignUpComponent,
    NavComponent,
    CategoryListComponent,
    HomeComponent,
    AboutComponent,
    AllProductsComponent,
    ProductComponent,
    ListComponent,
    TrackComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [DbService],
  bootstrap: [AppComponent],
  exports: [RouterModule],

})
export class AppModule { }
