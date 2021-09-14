import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Test } from 'src/app/interfaces/test.model';

@Injectable({
  providedIn: 'root'
})
export class TestService {

  private url = 'https://localhost:44303/api/test';

  constructor(private http: HttpClient) { }

  public getAll(): Observable<Test[]> {
    return this.http.get<Test[]>(this.url);
  }
}
