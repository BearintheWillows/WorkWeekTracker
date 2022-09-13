import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {catchError, Observable, map, tap} from "rxjs";
import {Run} from "../_models/run";
import {MessageService} from "./message.service";
import {X} from "@angular/cdk/keycodes";
import {DetailedRun} from "../_models/detailedRun";

@Injectable({
  providedIn: 'root'
})
export class RunsService {

  baseUrl = environment.apiUrl;

  constructor(private  http: HttpClient, private messageService: MessageService) { }

  getRuns(): Observable<Run[]>{
      this.messageService.add('RunService: Fetched simple Runs')
     return this.http.get<Run[]>(this.baseUrl + 'run');
  }

  getRunShopsById(id: string, day?: string): Observable<DetailedRun>{
    if(day != null){
      this.messageService.add(('RunServce: Fetched detailed run by id only'))

    }else {
      this.messageService.add('RunService: Fetched detailed Runs by id and day')
    }

    return this.http.get<DetailedRun>(this.baseUrl + 'run/' + id + '/route/' )

  }
}
