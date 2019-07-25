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
  public accounts: Account[];

  constructor(private accountsService: AccountsService) {}

  ngOnInit() {
    this.accountsService.getAccounts(1).subscribe((accounts: Account[]) => {
      this.accounts = accounts.sort(this.compare);
    });
  }

  public compare(a, b) {
    const nameA = a.nickname.toUpperCase();
    const nameB = b.nickname.toUpperCase();
    const balanceA = a.balance;
    const balanceB = b.balance;

    let comparison = 0;
    if (nameA > nameB) {
      comparison = 1;
    } else if (nameA < nameB) {
      comparison = -1;
    } else {
      if (balanceA > balanceB) {
        comparison = 1;
      } else if (balanceA < balanceB) {
        comparison = -1;
      }
    }
    return comparison;
  }
}
