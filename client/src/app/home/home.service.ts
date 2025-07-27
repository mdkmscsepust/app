import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  constructor(private httpClient: HttpClient) {}
  getMessage(): Observable<any> {
    return this.httpClient.get<any>('https://friendly-umbrella-x54w5w5pgj942v594-8000.app.github.dev/llm');
  }
}
