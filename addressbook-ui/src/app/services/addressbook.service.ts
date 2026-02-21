import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AddressbookService {

  private baseUrl = 'https://localhost:7215/api/AddressBook'; 

  constructor(private http: HttpClient) { }

  getAllAddressbook(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl);
  }

  addAddressbook(entry: any): Observable<any> {
    return this.http.post(this.baseUrl, entry);
  }

  updateAddressbook(id: number, entry: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, entry);
  }

  deleteAddressbook(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
