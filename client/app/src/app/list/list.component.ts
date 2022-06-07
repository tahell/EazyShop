import { Component, OnInit } from '@angular/core';
import { Product } from '../model/Product';
import { DbService } from '../services/db.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  list: Array<Product> = new Array<Product>()
  constructor(private db:DbService) { }

  ngOnInit(): void {
    this.list=this.db.allProducts
  }

}
