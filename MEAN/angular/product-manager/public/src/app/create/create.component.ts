import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})

export class CreateComponent implements OnInit {

  product: any;
  errors = [];
  errorsPresent: Boolean;

  constructor(private route: ActivatedRoute, private router: Router, private _httpservice: HttpService) { }

  ngOnInit() {

    this.product = { title: '', price: 0, image: '' };

  }

  onClick(e) {

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
      console.log("Product created: ", this.product);
      let newProduct = this._httpservice.create(this.product);

      newProduct.subscribe(data => {

        if (data['errorMessage'] == 'error') {
          this.errorsPresent = true;

          for (let item in data['data'].errors) {
            this.errors.push(data['data'].errors[item]);
            console.log("Errors:", data['data'].errors[item]);
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