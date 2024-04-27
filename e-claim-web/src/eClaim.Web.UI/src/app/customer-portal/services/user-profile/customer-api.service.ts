import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CustomerAddress } from '../../models/user-profile/customer-address.model'; // Make sure the import statement is correct

@Injectable({
  providedIn: 'root'
})
export class CustomerApiService {
  private baseUrl = 'http://customerportalapi-dev.us-east-1.elasticbeanstalk.com/api/Customer';

  constructor(private http: HttpClient) { }

  getCustomerAddressById(id: number): Observable<CustomerAddress> {
    return this.http.get<CustomerAddress>(`${this.baseUrl}/${id}`);
  }

  getAllCustomerAddresses(): Observable<CustomerAddress[]> {
    return this.http.get<CustomerAddress[]>(`${this.baseUrl}`);
  }

  createCustomerAddress(customerAddress: CustomerAddress): Observable<CustomerAddress> {
    return this.http.post<CustomerAddress>(`${this.baseUrl}`, customerAddress);
  }

  deleteCustomerAddress(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  updateCustomerAddress(customerAddress: CustomerAddress): Observable<CustomerAddress> {
    return this.http.put<CustomerAddress>(`${this.baseUrl}`, customerAddress);
  }
}
