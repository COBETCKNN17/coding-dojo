import { Component, OnInit } from '@angular/core';
import { HttpService } from './http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'Restful Tasks API';
  tasks;
  taskIndex;
  taskIndex1;
  clicked = false;

  constructor(private _httpService: HttpService) { }

  ngOnInit() {
    // this.getTasksFromService();
  }

  showDetails($event,taskIndex){
    this.clicked = true;
    this.taskIndex1=this.tasks[taskIndex];
    console.log(this.taskIndex1);
  }

  getTasksFromService() {
    let observable = this._httpService.getTasks();
    observable.subscribe(data => {
      console.log("Got our tasks!", data);
      this.tasks = data;
    });
  }
}
