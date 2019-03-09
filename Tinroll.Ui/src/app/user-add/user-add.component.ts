import { Component, OnInit, Input } from '@angular/core';
import { RestService } from '../rest.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-user-add',
  templateUrl: './user-add.component.html',
  styleUrls: ['./user-add.component.css']
})
export class UserAddComponent implements OnInit {

  @Input() userData:any = { userName:'', description: '', email: '' };

  constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
  }

  addUser() {
    this.rest.addUser(this.userData).subscribe((result) => {
      this.router.navigate(['/user-details/'+result._id]);
    }, (err) => {
      console.log(err);
    });
  }

}