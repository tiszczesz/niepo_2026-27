import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoginScreen } from './components/login-screen/login-screen';

@Component({
  imports: [RouterOutlet, LoginScreen],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('angular_cw1');
}
