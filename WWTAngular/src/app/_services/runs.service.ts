import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MessageService} from "./message.service";
import {DetailedRun} from "../_models/detailedRun";
import {baseRun} from "../_models/baseRun";

@Injectable({
  providedIn: 'root'
})
export class RunsService {

  baseUrl = environment.apiUrl;

  constructor(
    private  http: HttpClient,
    private messageService: MessageService
  ) { }

  //Retrieve all "simple" runs
  getRuns(): Observable<baseRun[]>{
      this.messageService.add('RunService: Fetched simple Runs')
     return this.http.get<baseRun[]>(this.baseUrl + 'run');
  }

  //Retrieve runs via id and/or day of week. Returns "Detailed" run
  getRunShopsById(id: string, day?: string): Observable<DetailedRun>{
    if(day != null){
      this.messageService.add(('RunServce: Fetched detailed run by id only'))

    }else {
      this.messageService.add('RunService: Fetched detailed Runs by id and day')
    }

    return this.http.get<DetailedRun>(this.baseUrl + 'run/' + id + '/route/' )

  }
}
