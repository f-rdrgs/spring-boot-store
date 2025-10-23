import { JsonPipe } from '@angular/common';
import { Component, effect, Signal, signal } from '@angular/core';
import {FormGroup, FormControl, FormsModule, Validators, ReactiveFormsModule } from '@angular/forms';
import { LoginAttempt } from 'src/app/shared/models/auth/login-data';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css'],
  imports:[ReactiveFormsModule],
  standalone: true
})
export class UserLoginComponent implements LoginAttempt{
  _email: string = ""
  _password: string = "";

  email_data = signal<string>("")
  password_data = signal<string>("")


  
  userLoginForm = new FormGroup({
    email: new FormControl(this._email,[Validators.required,Validators.email]),
    password: new FormControl(this._password,[Validators.required,])
  })

  private updateInfo = effect(() => {
    this._email = this.email_data.toString()
    this._password= this.password_data.toString()
  })

    onSubmit(){
    console.warn(this.userLoginForm.value);
  }
}
