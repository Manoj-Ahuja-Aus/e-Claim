import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { CustomerAddress } from '../../models/user-profile/customer-address.model';
import { CustomerApiService } from './customer-api.service';

describe('CustomerApiService', () => {
  let service: CustomerApiService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [CustomerApiService]
    });

    service = TestBed.inject(CustomerApiService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should retrieve a customer address by ID', () => {
    const expectedAddress: CustomerAddress = {
      Id: 1,
      AddressLine1: '123 Main St',
      AddressLine2: '',
      City: 'Anytown',
      State: 'CA',
      PostalCode: '12345',
      Country: 'USA'
    };

    service.getCustomerAddressById(1).subscribe(address => {
      expect(address).toEqual(expectedAddress);
    });

    const req = httpMock.expectOne(`${service['baseUrl']}/1`);
    expect(req.request.method).toBe('GET');
    req.flush(expectedAddress);
  });

  it('should retrieve all customer addresses', () => {
    const expectedAddresses: CustomerAddress[] = [
      {
        id: 1,
        AddressLine1: '123 Main St',
        AddressLine2: '',
        City: 'Anytown',
        State: 'CA',
        PostalCode: '12345',
        Country: 'USA'
      },
      {
        id: 2,
        AddressLine1: '456 Elm St',
        AddressLine2: '',
        City: 'Othertown',
        State: 'CA',
        PostalCode: '67890',
        Country: 'USA'
      }
    ];

    service.getAllCustomerAddresses().subscribe(addresses => {
      expect(addresses).toEqual(expectedAddresses);
    });

    const req = httpMock.expectOne(`${service['baseUrl']}`);
    expect(req.request.method).toBe('GET');
    req.flush(expectedAddresses);
  });

  it('should create a new customer address', () => {
    const newAddress: CustomerAddress = {
      Id: 0,
      AddressLine1: '789 Maple St',
      AddressLine2: '',
      City: 'Somewhere',
      State: 'CA',
      PostalCode: '13579',
      Country: 'USA'
    };

    service.createCustomerAddress(newAddress).subscribe(address => {
      expect(address).toEqual({ ...newAddress, id: 3 });
    });

    const req = httpMock.expectOne(`${service['baseUrl']}`);
    expect(req.request.method).toBe('POST');
    req.flush({ ...newAddress, Id: 3 });
  });

  it('should delete an existing customer address', () => {
    const id = 2;

    service.deleteCustomerAddress(id).subscribe(response => {
      expect(response).toBeTruthy();
    });

    const req = httpMock.expectOne(`${service['baseUrl']}/${id}`);
    expect(req.request.method).toBe('DELETE');
    req.flush({});
  });
})
