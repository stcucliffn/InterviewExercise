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
      this.accounts = accounts;
    });
  }
}
