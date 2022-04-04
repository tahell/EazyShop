import { Component, OnInit } from '@angular/core';
import { DbService } from 'src/app/services/db.service';
import { User } from 'src/app/model/User';
import { FormControl, FormGroup } from '@angular/forms';
import { Signin } from 'src/app/model/sign-in';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  SignInForm: any;
  constructor(private db: DbService) { }

  ngOnInit(): void {
    this.SignInForm = new FormGroup({
      fn: new FormControl(''),
      pass: new FormControl(''),
    })
  }

  doSignIn() {
    console.log(this.SignInForm);
    console.log("this.SignInForm.controls.fn.value: "+this.SignInForm.controls.fn.value);
    console.log("this.SignInForm.controls.pass.value: "+this.SignInForm.controls.pass.value);
    
    const signin: Signin = {
      User_Name: this.SignInForm.controls.fn.value,
      Password: this.SignInForm.controls.pass.value,
    }
    console.log("signin: "+signin);

    this.db.Sign(signin).subscribe(res => {
      console.log(res)

      if (res == null)
        alert("שגיאת שרת")
      else
        alert("נוסף בהצלחה")
    })
  }




}
