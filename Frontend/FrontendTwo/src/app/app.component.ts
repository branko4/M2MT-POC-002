import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FrontendTwo';

  constructor(private http: HttpClient) { }

  doSomething() {
    this.http.get('/one/be/weatherforecast').subscribe();;
  }
}
