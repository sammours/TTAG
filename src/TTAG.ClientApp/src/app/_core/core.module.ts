import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { SharedModule } from '../_shared/shared.module';
import { MainNavComponent } from './components/main-nav/main-nav.component';


const COMPONENTS = [MainNavComponent];

@NgModule({
  declarations: [...COMPONENTS],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
  ],
  exports: [...COMPONENTS]
})
export class CoreModule {}
