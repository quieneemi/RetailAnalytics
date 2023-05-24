import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Table} from "../tables/tables";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class OffersService {
  constructor(private http: HttpClient) {}

  public execute(offerName: string, values: string[]): Observable<Table> {
    return this.http.post<Table>('/api/offers/' + offerName, values, {
      headers: { Authorization: 'Bearer ' + localStorage.getItem('jwt') },
    });
  }
}
