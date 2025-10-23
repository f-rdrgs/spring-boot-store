import { Component } from '@angular/core';
import { LoginService } from 'src/app/core/auth/login/login.service';
import { UserLoginComponent } from 'src/app/shared/components/form/user-login/user-login.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone:true,
  imports:[UserLoginComponent]
})
export class LoginComponent {
  constructor(private login: LoginService){
  }

  
}
