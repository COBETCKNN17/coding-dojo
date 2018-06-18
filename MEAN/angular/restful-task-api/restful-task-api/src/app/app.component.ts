import { Component, OnInit } from '@angular/core';
import { HttpService } from './http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'Restful Tasks API';
  new_task: any;
  updated_task: any;
  tasks: any;
  task = {};

  constructor(private _httpService: HttpService) { }

  ngOnInit() {
    this.new_task = { title: "", description: "" }
    this.updated_task = { title: "", description: "" }
  }


  newTask() {
    let observable = this._httpService.newTask(this.new_task);
    observable.subscribe(data => {
      console.log("newTask says:", data)
    })
    this.new_task = { title: "", description: "" }
  }

  getTasks() {
    let observable = this._httpService.getTasks();
    observable.subscribe(data => {
      this.tasks = data;
      console.log("Got the tasks!", this.tasks);
    })
  }

  showOne(id) {
    console.log(id);
    let observable = this._httpService.showOne(id);
    observable.subscribe(data => {
      this.task = data;
      console.log(this.task);
    });
  }

  editTask(id) {
    let observable = this._httpService.editTask(id, this.updated_task);
    observable.subscribe(data => {
      console.log(data)
    })
    this.updated_task = { title: "", description: "" }
  }

  deleteTask(id) {
    let observable = this._httpService.deleteTask(id);
    observable.subscribe(data => {
      console.log(data);
    })
  }
}
