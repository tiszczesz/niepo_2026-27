import { Component, effect, signal } from '@angular/core';
import { LOGIN_FORM_DEFAULT } from './login-screen.model';
import { form, FormRoot, FormField, required } from '@angular/forms/signals';

@Component({
  selector: 'app-login-screen',
  templateUrl: './login-screen.html',
  styleUrl: './login-screen.css',
  imports: [FormRoot, FormField],
})
export class LoginScreen {
  loginModel = signal({...LOGIN_FORM_DEFAULT})
  form = form(this.loginModel,
    (path)=>{
      required(path.login,{message:"login jest niezbędny"})
    }
  )

  /**
   *
   */
  constructor() {
   effect(()=>console.log(this.loginModel()))
    
  }
}
