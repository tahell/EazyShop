import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/model/Product';
import { DbService } from 'src/app/services/db.service';

@Component({
  selector: 'app-all-products',
  templateUrl: './all-products.component.html',
  styleUrls: ['./all-products.component.css']
})
export class AllProductsComponent implements OnInit {
  products: Array<Product> = new Array<Product>()

  constructor(private db: DbService) { }

  ngOnInit(): void {
    this.products = this.db.allProductsForCategory
  }

}
