import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/model/Category';
import { Product } from 'src/app/model/Product';
import { DbService } from 'src/app/services/db.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  super="assets/super.png"
  Bag="assets/Bag.png"
  logo="assets/logo.png"
  // superon="assets/"
  selectedCategory!: Category;
  allCategories: Category[] = []
  allProductsToSelectedCategory:Product[]=[]
  constructor(private db: DbService, private router:Router) { }

  ngOnInit(): void {
    this.db.getAllCategories().subscribe(
      (res) => {
        this.allCategories = res;
        console.log(res);
      })
  }


  showProducts(event:any) {

    console.log(event.target.id)

    this.selectedCategory=this.allCategories.filter(c=>c.Class_Code==event.target.id)[0];
    console.log(this.selectedCategory);
    
    // console.log(this.selectedCategory)
    this.db.getAllProducts(this.selectedCategory.Class_Code).subscribe(res => {
      this.allProductsToSelectedCategory = res;

      this.db.allProducts=this.allProductsToSelectedCategory;
      console.log(this.allProductsToSelectedCategory);
this.router.navigate(['all-products'])
      
      
    })
  }

}
