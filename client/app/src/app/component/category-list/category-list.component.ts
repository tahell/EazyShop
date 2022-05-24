import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/model/Category';
import { DbService } from 'src/app/services/db.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  selectedCategory!: string;
  category:Category[]=[];
  constructor(private db:DbService) { }

  ngOnInit(): void {
  }
  
  showCategory(){
    console.log(this.selectedCategory)
     this.db.getAllProducts(Number.parseInt(this.selectedCategory)).subscribe(res =>{
       this.category=res;
    })
   }
}
