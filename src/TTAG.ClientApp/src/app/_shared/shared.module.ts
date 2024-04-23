import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import {MatToolbarModule} from '@angular/material/toolbar';
// import { ArtCategoryPipe } from './pipes/art-category.pipe';

const COMPONENTS = [];

@NgModule({
  declarations: [...COMPONENTS],
  imports: [
    CommonModule,
    RouterModule,
    MatToolbarModule
  ],
  exports: [...COMPONENTS]
})
export class SharedModule {}
