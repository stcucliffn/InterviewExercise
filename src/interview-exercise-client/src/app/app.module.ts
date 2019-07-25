import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AccountDetailComponent } from './components/account-detail/account-detail.component';
import { AccountListComponent } from './components/account-list/account-list.component';
import { AccountListItemComponent } from './components/account-list-item/account-list-item.component';
import { SpinnyComponent } from './components/spinny/spinny.component';
import { ErrorComponent } from './components/error/error.component';
import { AccountEditComponent } from './components/account-edit/account-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    AccountDetailComponent,
    AccountListComponent,
    AccountListItemComponent,
    SpinnyComponent,
    ErrorComponent,
    AccountEditComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
