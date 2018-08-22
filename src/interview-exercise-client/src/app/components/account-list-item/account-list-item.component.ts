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

  constructor() {}

  ngOnInit() {}
}
