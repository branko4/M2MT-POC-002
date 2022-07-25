import { DOCUMENT } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Message } from './model/message.model';

class Link {
  public url: string = "";
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FrontendTwo';
  message = new Message("no message");

  constructor(private http: HttpClient, @Inject(DOCUMENT) private document: Document) { }

  doSomething() {
    this.http.post<Link>('/two/be/weatherforecast', this.message).subscribe((redirectLink) => {
      console.log(redirectLink);
      this.document.location.href = redirectLink.url;
    });
  }
}
