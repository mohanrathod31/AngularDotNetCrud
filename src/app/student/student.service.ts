import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Student} from './student';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  readonly apiUrl = "https://localhost:7065/api";

  constructor(private httpClient: HttpClient) { }

  get(): Observable<any> {
    return this.httpClient.get<Student[]>(this.apiUrl + '/Student/GetAllStudents').pipe(catchError(this.handleError))
  }

  post(payload: Student) {
    return this.httpClient.post<Student>(this.apiUrl + '/Student/CreateStudent',payload);
    
  }

  update(payload: Student) {
    return this.httpClient.put<Student>(this.apiUrl + '/Student/Edit',payload); 
  }

  delete(Id: number) {
    return this.httpClient.delete(this.apiUrl + `/Student/Delete/${Id}`);
  }

  handleError(err: Response){
    return throwError(err)
  }
}
