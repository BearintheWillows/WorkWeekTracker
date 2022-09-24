import {Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {catchError, Observable, of, tap} from "rxjs";
import {MessageService} from "./message.service";
import {DetailedRun} from "../_models/detailedRun";
import {baseRun} from "../_models/baseRun";

@Injectable({
  providedIn: 'root'
})
export class RunsService {

  baseUrl = environment.apiUrl;

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) {
  }

  //Retrieve all "simple" runs
  getRuns(): Observable<baseRun[]> {
    return this.http.get<baseRun[]>(this.baseUrl + 'run')
      .pipe(
        tap(_ => this.log('Fetched simple runs')),
        catchError(this.handleError<baseRun[]>('getRuns', []))
      );
  }

  //Retrieve runs via id and/or day of week. Returns "Detailed" run
  getRunShopsById(id: string | null, day?: string | null): Observable<DetailedRun> {
    if(day == null) {
      this.log(('Fetched detailed run by id only'))
      return this.http.get<DetailedRun>(this.baseUrl + 'run/' + id + '/route').pipe(
        tap(_ => this.log(`fetched detailedHero. id = ${id}. Day = ${day}`)))
    } else {
      this.log(' Fetched detailed Runs by id and day')
      return this.http.get<DetailedRun>(this.baseUrl + 'run/' + id + '/route/' + day).pipe(
        tap(_ => this.log(`fetched detailedRun. id = ${id}, day = ${day}`)))
    }
  }

  private log(message: string) {
    this.messageService.add(`RunService: ${message}`);

  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   *
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
