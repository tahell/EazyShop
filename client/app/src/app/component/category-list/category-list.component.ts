import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/model/Category';
import { Product } from 'src/app/model/Product';
import { DbService } from 'src/app/services/db.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
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

      this.db.allProductsForCategory=this.allProductsToSelectedCategory;
      console.log(this.allProductsToSelectedCategory);
this.router.navigate(['all-products'])
      
      
    })
  }
}
