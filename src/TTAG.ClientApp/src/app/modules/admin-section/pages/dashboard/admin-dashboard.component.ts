import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

type Section = 'Dashboard' | 'Arts' | 'Artists';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.scss']
})
export class AdminDashboardComponent implements OnInit {
  public term = '';
  public activeSection: Section = 'Dashboard';

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  public onSearchClicked() {
    if (this.term !== '') {
      this.router.navigate(['/art'], { queryParams: { term: this.term } });
    }
  }

  public onSectionChanged(activeSection: Section) {
    this.activeSection = activeSection;
  }
}
