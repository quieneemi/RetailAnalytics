import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Table} from "./tables";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class TablesService {
  constructor(private http: HttpClient) {}

  public get(tableName: string, pageIndex: number = 0, pageSize: number = 0): Observable<Table> {
    const params: string = '?pageIndex=' + pageIndex + '&pageSize=' + pageSize;
    return this.http.get<Table>('/api/tables/' + tableName + params, {
      headers: { Authorization: 'Bearer ' + localStorage.getItem('jwt') }
    });
  }

  public insert(tableName: string, values: string[]): Observable<any> {
    return this.http.post('/api/tables/' + tableName, values, {
      headers: { Authorization: 'Bearer ' + localStorage.getItem('jwt') }
    });
  }

  public update(tableName: string, values: string[]): Observable<any> {
    return this.http.put('/api/tables/' + tableName, values, {
      headers: { Authorization: 'Bearer ' + localStorage.getItem('jwt') }
    });
  }

  public delete(tableName: string, values: string[]): Observable<any> {
    return this.http.delete('/api/tables/' + tableName, {
      headers: { Authorization: 'Bearer ' + localStorage.getItem('jwt') },
      body: values
    });
  }

  public import(tableName: string, formData: FormData): Observable<any> {
    return this.http.post('/api/tables/' + tableName + '/import', formData, {
      headers: { Authorization: 'Bearer ' + localStorage.getItem('jwt') }
    });
  }
}
