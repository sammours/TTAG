import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
   {
      path: '',
      children: [
         { path: '', pathMatch: 'full', redirectTo: 'dashboard' },
         {
            path: 'dashboard',
            loadChildren: () => import('./modules/dashboard-section/dashboard-section.module').then((m) => m.DashboardSectionModule)
         },
         {
            path: 'art',
            loadChildren: () => import('./modules/art-section/art-section.module').then((m) => m.ArtSectionModule)
         },
         {
            path: 'admin',
            loadChildren: () => import('./modules/admin-section/admin-section.module').then((m) => m.AdminSectionModule)
         }
      ]
   }
];
@NgModule({
   imports: [RouterModule.forRoot(routes)],
   exports: [RouterModule]
})
export class AppRoutingModule {}
