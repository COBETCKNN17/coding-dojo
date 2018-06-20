import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router'

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})

export class ListComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router, private _httpservice: HttpService) { }

  errors: any;
  errorsPresent: Boolean;
  products: any;

  ngOnInit() {

    this.onLoad();

  }

  onLoad() {

    let allProducts = this._httpservice.show();

    allProducts.subscribe(data => {
      console.log('Got all product data: ', data);
      if (data['message'] == 'error') {
        this.errorsPresent = true;
        this.errors = data['data'];

      }
      else {
        this.errorsPresent = false;
        this.products = data['data'];
      }
    })
  }

  delete(id) {
    console.log('Product ', id, ' has been deleted.');

    let tempValue = this._httpservice.delete(id);

    tempValue.subscribe(data => console.log(data));

    this.onLoad();

  }



}