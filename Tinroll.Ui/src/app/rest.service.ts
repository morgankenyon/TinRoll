import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

const endpoint = 'https://localhost:5001/api/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class RestService {

  constructor(private http: HttpClient) { }

  private extractData(res: Response) {
    let body = res;
    return body || { };
  }

  getUsers(): Observable<any> {
    return this.http.get(endpoint + 'user').pipe(
      map(this.extractData));
  }
  
  getUser(id): Observable<any> {
    return this.http.get(endpoint + 'user/' + id).pipe(
      map(this.extractData));
  }
  
  addUser (user): Observable<any> {
    console.log(user);
    return this.http.post<any>(endpoint + 'user', JSON.stringify(user), httpOptions).pipe(
      tap((product) => console.log(`added product w/ id=${product.id}`)),
      catchError(this.handleError<any>('addUser'))
    );
  }
  
  updateUser (user): Observable<any> {
    return this.http.put(endpoint + 'user/', JSON.stringify(user), httpOptions).pipe(
      tap(_ => console.log(`updated product id=${user.userId}`)),
      catchError(this.handleError<any>('updateUser'))
    );
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
