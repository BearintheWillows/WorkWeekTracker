import { Component } from '@angular/core';
import {MessageService} from "./_services/message.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Work Week Tracker';

  constructor() {
  }
}
