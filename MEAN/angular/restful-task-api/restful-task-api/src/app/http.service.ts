import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class HttpService {

  constructor(private _http: HttpClient) {
    this.getTasks();
  }

  getTasks() {
    //let tempObservable = this._http.get('/tasks');
    //tempObservable.subscribe(data => console.log("Got our tasks!", data));
    return this._http.get('/tasks');
  }

  showOne(id) {
    return this._http.get('/tasks/' + id);
  }

  newTask(new_task) {
    return this._http.post('/tasks/new', new_task);
  }

  editTask(id, updated_task) {
    return this._http.put('/tasks/' + id, updated_task);
  }

  deleteTask(id) {
    return this._http.delete('/tasks/' + id);
  }

}
