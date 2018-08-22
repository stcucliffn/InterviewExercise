import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { AccountsService } from '../../core/services/accounts.service';
import { Account } from '../../core/models/account';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-account-detail',
  templateUrl: './account-detail.component.html',
  styleUrls: ['./account-detail.component.scss']
})
export class AccountDetailComponent implements OnInit {
  public account: Account;

  constructor(
    private accountsService: AccountsService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    // TODO: Do not hardcode MemberId
    // f1ce4c96-703e-46c0-973f-41a1eba95731

    this.accountsService
      .getAccount(this.route.snapshot.paramMap['id'], 1)
      .subscribe((account: Account) => {
        this.account = account;
      });
  }
}
