import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ArtListComponent } from './pages/list/art-list.component';

const routes: Routes = [
   { path: '', component: ArtListComponent, pathMatch: 'full' }
];

@NgModule({
   imports: [RouterModule.forChild(routes)],
   exports: [RouterModule]
})
export class ArtSectionRoutingModule {}
