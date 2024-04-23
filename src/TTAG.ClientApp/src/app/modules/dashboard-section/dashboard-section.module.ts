import { NgModule } from '@angular/core';

import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { DashboardSectionRoutingModule } from './dashboard-section-routing.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    FormsModule,
    DashboardSectionRoutingModule
  ]
})
export class DashboardSectionModule { }
