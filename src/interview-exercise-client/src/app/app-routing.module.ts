import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AccountListComponent } from './components/account-list/account-list.component';
import { ErrorComponent } from './components/error/error.component';
import { AccountDetailComponent } from './components/account-detail/account-detail.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'accounts',
    pathMatch: 'full'
  },
  {
    path: 'accounts/detail/:id',
    component: AccountDetailComponent
  },
  {
    path: 'accounts',
    component: AccountListComponent,
    pathMatch: 'full'
  },
  {
    path: 'error',
    component: ErrorComponent
  },
  {
    path: '**',
    redirectTo: 'error'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { enableTracing: false })],
  exports: [RouterModule]
})
export class AppRoutingModule {}
