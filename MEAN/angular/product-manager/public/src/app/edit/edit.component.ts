import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { HttpService } from '../http.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router'

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})

export class EditComponent implements OnInit {

  @Output() myEvent = new EventEmitter();
  id: any;
  product: any;
  errors = [];
  errorsPresent: Boolean;
  price;
  image;
  title;

  constructor(private route: ActivatedRoute, private router: Router, private _httpservice: HttpService) { }

  ngOnInit() {

    this.id = this.route.snapshot.paramMap.get('id');
    let thisProduct = this._httpservice.singleProduct(this.id);

    thisProduct.subscribe(data => {
      this.title = data['data']['title'];
      this.price = data['data']['price'];
      this.image = data['data']['image'];

    })

    this.product = { title: '', price: 0, image: '', id: this.id };

    this.edit();

  }

  edit() {

    console.log("Editing a product!");

    let tempproductID = this._httpservice.singleProduct(this.id);

    tempproductID.subscribe(data => {

      console.log(data);

      this.product.title = data['data']['title'];
      this.product.price = data['data']['price'];
      this.product.image = data['data']['image'];

    })

    console.log("YES:", this.product);

  }

  onClick(e) {

    console.log("CLICKED!");

    this.errors = [];

    if (this.product.title.length < 4) {
      this.errorsPresent = true;
      this.errors.push({ 'errorMessage': 'Product title must have a title at least 4 characters long!' });
    }
    else if (this.product.price == 0 || this.product.price == null) {
      this.errorsPresent = true;
      this.errors.push({ 'errorMessage': "Price is required!" });
    }
    else {
      this.errorsPresent = false;
      this.errors = [];
      console.log("Product edited: ", this.product);
      let editedProduct = this._httpservice.edit(this.id, this.product);

      editedProduct.subscribe(data => {

        if (data['errorMessage'] == 'error') {
          this.errorsPresent = true;

          for (let item in data['data'].errors) {
            this.errors.push(data['data'].errors[item]);
            console.log("Errors: ", data['data'].errors[item]);
          }
        }

        else {
          this.errorsPresent = false;
          this.router.navigate(['/list']);
        }

      });

      this.router.navigate(['/list']);
    }
  }

  cancel() {

    this.product = { title: '', price: 0, image: '' };
    this.router.navigate(['/list']);

  }


}