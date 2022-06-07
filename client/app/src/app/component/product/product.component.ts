import { Component, Input, OnInit } from '@angular/core';
import { Product } from 'src/app/model/Product';
import { DbService } from 'src/app/services/db.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {


  @Input() myProduct: Product = new Product();
  constructor(private db: DbService) { }

  ngOnInit(): void {
  }

  addToCart() {
    this.db.allProducts.push(this.myProduct)
  }

}
