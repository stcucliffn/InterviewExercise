import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { Account } from '../../core/models/account';

@Component({
  selector: '[app-account-list-item]',
  templateUrl: './account-list-item.component.html',
  styleUrls: ['./account-list-item.component.scss']
})
export class AccountListItemComponent implements OnInit {
  @Input()
  account: Account;
  @Output()
  updateAccount = new EventEmitter<Account>();
  @Output()
  deleteAccount = new EventEmitter<string>();

  constructor() {}

  ngOnInit() {}

  public onUpdate(account: Account): void {
    this.updateAccount.emit(account);
  }

  public onDelete(accountId: string): void {
    this.deleteAccount.emit(accountId);
  }
}
