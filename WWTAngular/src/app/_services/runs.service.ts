import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {Run} from "../_models/run";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class RunsService {

  baseUrl = environment.apiUrl;
  private runs: Object = [];

  constructor(private  http: HttpClient) { }

  getRuns(){
      return this.http.get(this.baseUrl + 'run');




  }
}
