import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Robert Vo Learning page';
  getYear() {
    return new Date().getUTCFullYear();
  }

  get webTitle(): string {
    return "Learning Page";
  }
}
