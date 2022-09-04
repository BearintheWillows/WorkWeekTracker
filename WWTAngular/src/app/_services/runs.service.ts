import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {catchError, Observable, map, tap} from "rxjs";
import {Run} from "../_models/run";

@Injectable({
  providedIn: 'root'
})
export class RunsService {

  baseUrl = environment.apiUrl;
  private runs: Object = [];

  constructor(private  http: HttpClient) { }

  getRuns(): Observable<Run[]>{

      return this.http.get<Run[]>(this.baseUrl + 'run')
        .pipe(
          catchError(this.handleError<Run[]>('getRuns', []))

        );




  }
}
