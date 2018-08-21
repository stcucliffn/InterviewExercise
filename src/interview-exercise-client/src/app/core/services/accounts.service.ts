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

  public getAccounts(): Observable<Account[]> {
    return this.http.get<Account[]>(this.apiUrl);
  }

  public getAccount(id: string): Observable<Account> {
    return this.http.get<Account>(`${this.apiUrl}/${id}`);
  }

  public addAccount(account: Account): Observable<Account> {
    account.id = uuid();
    return this.http.post<Account>(this.apiUrl, account);
  }

  public updateAccount(account: Account): Observable<Account> {
    return this.http.put<Account>(`${this.apiUrl}/${account.id}`, account);
  }

  public deleteAccount(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
