import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { AccountsService } from '../../core/services/accounts.service';
import { Account } from '../../core/models/account';

@Component({
  selector: 'app-account-detail',
  templateUrl: './account-detail.component.html',
  styleUrls: ['./account-detail.component.scss']
})
export class AccountDetailComponent implements OnInit {
  public account: Account;

  constructor(
    private route: ActivatedRoute,
    private accountsService: AccountsService
  ) {}

  ngOnInit() {
    this.accountsService
      .getAccount(this.route.snapshot.paramMap.get('id'), 1)
      .subscribe((account: Account) => {
        this.account = account;
      });
  }
}
