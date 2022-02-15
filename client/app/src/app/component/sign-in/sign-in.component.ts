import { Component, OnInit } from '@angular/core';
import { DbService } from 'src/app/services/db.service';
import { User } from 'src/app/model/User';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  user: User[] = [];
  constructor(private db: DbService) { }

  ngOnInit(): void {
  }
  getUser(){
    this.db.GetUser().subscribe((res: User[]) =>{
      this.user = res;
    })
  }


}
