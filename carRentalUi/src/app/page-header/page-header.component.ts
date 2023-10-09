import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router'; 
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-page-header',
  templateUrl: './page-header.component.html',
  styleUrls: ['./page-header.component.scss'],
})
export class PageHeaderComponent implements OnInit {
  @Output() menuClicked = new EventEmitter<boolean>();

  name: any;

  constructor(private router: Router, private userService: UserService) {} 

  ngOnInit() {}

  // Function to handle the login event
  login() {
    this.router.navigate(['/login']);}

  // Function to handle the logout event
  logout() {
   
    this.userService.removeToken();
    this.router.navigate(['']);}

  isThere(): Boolean {
    if (localStorage.getItem('token')) {
      let userPayload = this.userService.decodedToken();
      if (userPayload) {
        this.name = userPayload.name || '';
      }
      return true;
    }
    return false;
  }
}
