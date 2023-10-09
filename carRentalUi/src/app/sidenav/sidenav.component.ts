import { Component } from '@angular/core';
import { SideNavItems } from '../models/models';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss'],
})
export class SidenavComponent {
  sideNavContent: SideNavItems[] = [
    {
      title: 'Cars',
      link: 'cars/warehouse',
    },
    {
      title: 'Agreements',
      link: 'cars/show-agreement',
    },
  ];
  roles: any;

  constructor() {}

  ngOnInit() {}

  isThere(): Boolean {
    if (localStorage.getItem('token')) {
      return true;
    }
    return false;
  }
}
