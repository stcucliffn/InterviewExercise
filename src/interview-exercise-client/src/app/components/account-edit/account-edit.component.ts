import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { AccountsService } from '../../core/services/accounts.service';
import { Account } from '../../core/models/account';

@Component({
  selector: 'app-account-edit',
  templateUrl: './account-edit.component.html',
  styleUrls: ['./account-edit.component.scss']
})
export class AccountEditComponent implements OnInit {

  public account: Account;

  constructor(private accountsService: AccountsService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.accountsService.getAccount(this.route.snapshot.paramMap.get('id'), 1)
      .subscribe((account:Account) => this.account = account);
  }

  public saveAccount() {
    this.accountsService.editAccount(this.account)
    .subscribe((account:Account) => this.router.navigate(['accounts']));
  }
}
