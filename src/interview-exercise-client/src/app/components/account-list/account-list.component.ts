import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { AccountsService } from '../../core/services/accounts.service';
import { Account } from '../../core/models/account';

@Component({
  selector: 'app-account-list',
  templateUrl: './account-list.component.html',
  styleUrls: ['./account-list.component.scss']
})
export class AccountListComponent implements OnInit {
  public accounts$: Observable<Account[]>;

  constructor(private accountsService: AccountsService) {}

  ngOnInit() {
    this.accounts$ = this.accountsService.getAccounts();
  }

  public addAccount(): void {
    this.accountsService
      .addAccount({
        lastFour: '1234',
        type: 'Savings Account',
        accountHolder: 'Aaron Nay',
        balance: 0
      } as Account)
      .subscribe(
        (account: Account) => {
          this.accounts$ = this.accountsService.getAccounts();
        },
        error => console.log(error)
      );
  }

  public updateAccount(account: Account): void {
    account.balance += 100;
    this.accountsService.updateAccount(account).subscribe(
      (updatedAccount: Account) => {
        this.accounts$ = this.accountsService.getAccounts();
      },
      error => console.log(error)
    );
  }

  public deleteAccount(accountId: string): void {
    this.accountsService.deleteAccount(accountId).subscribe(
      () => {
        this.accounts$ = this.accountsService.getAccounts();
      },
      error => console.log(error)
    );
  }
}
