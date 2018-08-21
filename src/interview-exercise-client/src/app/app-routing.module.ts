import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AccountDetailComponent } from './components/account-detail/account-detail.component';
import { AccountListComponent } from './components/account-list/account-list.component';

const routes: Routes = [
  {
    path: 'accounts/add',
    component: AccountDetailComponent
  },
  {
    path: 'accounts/:id',
    component: AccountDetailComponent
  },
  {
    path: 'accounts',
    component: AccountListComponent
  },
  {
    path: '**',
    redirectTo: 'accounts'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
