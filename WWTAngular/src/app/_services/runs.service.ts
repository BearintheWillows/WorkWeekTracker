import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {catchError, Observable, map, tap} from "rxjs";
import {Run} from "../_models/run";
import {MessageService} from "./message.service";
import {X} from "@angular/cdk/keycodes";

@Injectable({
  providedIn: 'root'
})
export class RunsService {

  baseUrl = environment.apiUrl;
  private runs: any[] = [];

  constructor(private  http: HttpClient, private messageService: MessageService) { }

  getRuns(): Observable<Run[]>{

    this.messageService.add('RunService: Fetched Runs');
     return this.http.get<Run[]>(this.baseUrl + 'run');


  }
}
