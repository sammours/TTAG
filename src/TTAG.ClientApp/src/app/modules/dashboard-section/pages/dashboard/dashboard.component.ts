import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  public term = '';

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  public onSearchClicked() {
    if (this.term !== '') {
      this.router.navigate(['/art'], { queryParams: { term: this.term } });
    }

  }
}
