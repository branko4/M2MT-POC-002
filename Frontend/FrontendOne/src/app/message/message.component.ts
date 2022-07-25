import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

class Message {
  public content: string = ""
}

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent implements OnInit {
  public messageID: string = "";
  public message = "no message";

  constructor(private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    this.messageID = String(routeParams.get('messageId'));

    // this.messageID = productIdFromRoute;

    this.http.get<Message>(`/one/be/weatherforecast/${this.messageID}`).subscribe((data) => {
      console.log(data)
      this.message = data.content;
    });

    
    // error: (e) => console.log(e),
    // complete: console.info
  }

}
