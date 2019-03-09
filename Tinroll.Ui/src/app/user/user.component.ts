import { Component, OnInit } from '@angular/core';
import { RestService } from '../rest.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  users:any = [];

  constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.users = [];
    this.rest.getUsers().subscribe((data: {}) => {
      console.log(data);
      this.users = data;
    });
  }

  add() {
    this.router.navigate(['/user-add']);
  }

  // delete(id) {
  //   this.rest.deleteProduct(id)
  //     .subscribe(res => {
  //         this.getProducts();
  //       }, (err) => {
  //         console.log(err);
  //       }
  //     );
  // }

}