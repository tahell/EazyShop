import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '../model/Product';
import { DbService } from '../services/db.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  list: Array<Product> = new Array<Product>()
  isCollector = false;

  constructor(private db: DbService, private router: Router) { }

  ngOnInit(): void {
    this.list = this.db.allProducts;
    this.isCollector = this.db.isCollector;
  }
  doalert(){
    alert("הרשימה נוספה בהצלחה")

    this.router.navigate(['home'])
  }
  goTo() {

    this.db.calcPathToProduct().subscribe((res) => {
      console.log(res);
      this.db.myPath = res;
      this.router.navigate(['track']);

    });
    // 
  }

}
