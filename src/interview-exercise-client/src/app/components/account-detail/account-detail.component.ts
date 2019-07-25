import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { AccountsService } from '../../core/services/accounts.service';
import { Account } from '../../core/models/account';

@Component({
  selector: 'app-account-detail',
  templateUrl: './account-detail.component.html',
  styleUrls: ['./account-detail.component.scss']
})
export class AccountDetailComponent implements OnInit {

  public account: Account;

  constructor(private accountsService: AccountsService,
    private route: ActivatedRoute,
    private router: Router,) { }

  ngOnInit() {
    this.accountsService.getAccount(this.route.snapshot.paramMap.get('id'), 1)
      .subscribe((account:Account) => this.account = account);
  }

}
