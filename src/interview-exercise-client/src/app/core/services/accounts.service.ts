import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { v4 as uuid } from 'uuid';

import { Account } from '../models/account';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {
  private apiUrl = 'api/accounts';

  constructor(private http: HttpClient) {}

  public getAccounts(memberId: number): Observable<Account[]> {
    return this.http.get<Account[]>(`${this.apiUrl}/${memberId}`);
  }

  public getAccount(id: string): Observable<Account> {
    return this.http.get<Account>(`${this.apiUrl}/GetAccount/${id}`);
  }

  public editAccount(account: Account): Observable<Account> {
    return this.http.put<Account>(`${this.apiUrl}/${account.id}`, account);
  }
}
