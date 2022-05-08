import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Signup } from 'src/app/model/Sign-Up';
import { DbService } from 'src/app/services/db.service';


@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  SignUpForm:any;
  constructor(private db: DbService) { }

  ngOnInit(): void {
    this.SignUpForm = new FormGroup({
      fn: new FormControl(''),
      pass: new FormControl(''),
    })
  }

  doSignUp() {
    console.log(this.SignUpForm);
    console.log("this.SignUpForm.controls.fn.value: "+this.SignUpForm.controls.fn.value);
    console.log("this.SignUpForm.controls.pass.value: "+this.SignUpForm.controls.pass.value);
    
    const signup: Signup = {
      User_Name: this.SignUpForm.controls.fn.value,
      Password: this.SignUpForm.controls.pass.value,
    }
    console.log("signun: "+signup);

    this.db.Signu(signup).subscribe(es => {
      console.log(es)

      if (es == null)
        alert("שגיאת שרת")
      else
        alert("ההתחברות הושלמה")
    })
  }

}
