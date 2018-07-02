import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private _http:HttpClient) { }

  create(data){
    console.log('Create a product!', data);
    return this._http.post('/api/products', data);
    }

  show(){
    console.log('Get all products!');
    return this._http.get('/api/products');
  }

  singleProduct(id){
    console.log('Got one product!');
    return this._http.get('/api/products/'+ id);
  }

  edit(id, data){
    console.log('Edit a product!');
    return this._http.put('/api/products/'+id, data);
  }

  delete(id){
    console.log('Delete a product!');
    return this._http.delete('/api/products/'+id+'/delete/');
  }
}