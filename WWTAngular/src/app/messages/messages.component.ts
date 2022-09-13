import { Component, OnInit } from '@angular/core';
import {MessageService} from "../_services/message.service";

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {

  //Initialises new array of message strings
  messages: string[] = [];

  //Injects MessageService
  constructor(public messageService: MessageService) { }

  // Adds a message to the messages array
  add(message: string) {
    this.messages.push(message);

  }

  ///Removes all messages from messages array
  clear() {
    this.messages = [];

  }

}
