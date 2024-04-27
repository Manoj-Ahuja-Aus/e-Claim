import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CustomerAddress } from '../../models/user-profile/customer-address.model';
import { CustomerApiService } from '../../services/user-profile/customer-api.service';

@Component({
  selector: 'app-customer-address-list',
  templateUrl: './customer-address-list.component.html',
  styleUrls: ['./customer-address-list.component.css']
})

/// <summary>
/// This class is used to create a CustomerAddressListComponent which implements OnInit.
/// It also contains customerAddresses array, selectedCustomerAddress object and editForm FormGroup.
/// </summary>
/// <param name="customerAddresses">Array of CustomerAddress objects</param>
/// <param name="selectedCustomerAddress">Object of CustomerAddress</param>
/// <param name="editForm">FormGroup object</param>
/// <returns>
/// CustomerAddressListComponent object
/// </returns>
export class CustomerAddressListComponent implements OnInit {
  customerAddresses: CustomerAddress[] = [];
  selectedCustomerAddress: CustomerAddress = new CustomerAddress(1, 'Jack', 'wills', '', '', '', '');
  editForm: FormGroup = this.formBuilder.group({
    id: [''],
    addressLine1: ["", Validators.required],
    addressLine2: [""],
    city: ["", Validators.required],
    state: [""],
    postalCode: ["", Validators.required],
    country: ["", Validators.required]
  });

  isEditMode = true;

  /// <summary>
  /// Constructor to create a form with validators and ngOnInit to load customer addresses.
  /// </summary>
  constructor(private formBuilder: FormBuilder, private customerAddressService: CustomerApiService) {
    this.editForm = this.formBuilder.group({
      id: [''],
      addressLine1: ['', Validators.required],
      addressLine2: [''],
      city: ['', Validators.required],
      state: [''],
      postalCode: ['', Validators.required],
      country: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.loadCustomerAddresses();
  }

  /// <summary>
  /// Loads all customer addresses from the customerAddressService and stores them in the customerAddresses array.
  /// </summary>
  /// <returns>
  /// An array of CustomerAddress objects.
  /// </returns>
  loadCustomerAddresses() {
    this.customerAddressService.getAllCustomerAddresses().subscribe((data: CustomerAddress[]) => {
      this.customerAddresses = data;
      console.log(this.customerAddresses); // Add this line to debug
    });
  }


  /// <summary>
  /// Creates a new customer address using the values from the edit form.
  /// </summary>
  /// <returns>
  /// Nothing is returned.
  /// </returns>
  createCustomerAddress() {
    this.customerAddressService.createCustomerAddress(this.editForm.value).subscribe(() => {
      this.loadCustomerAddresses();
      this.editForm.reset();
    });
  }

  /// <summary>
  /// Updates the customer address using the customer address service.
  /// </summary>
  /// <returns>
  /// Nothing.
  /// </returns>
  updateCustomerAddress() {
    this.customerAddressService.updateCustomerAddress(this.editForm.value).subscribe(() => {
      this.loadCustomerAddresses();
      this.editForm.reset();
      this.isEditMode = false;
    });
  }

  /// <summary>
  /// Sets the editForm to the values of the customerAddress and sets isEditMode to true.
  /// </summary>
  /// <param name="customerAddress">The customer address to be edited.</param>
  /// <returns>
  /// No return value.
  /// </returns>
  editCustomerAddress(customerAddress: CustomerAddress) {
    this.editForm.reset();
    this.isEditMode = true;

    this.editForm.patchValue({
      id: customerAddress.id,
      addressLine1: customerAddress.addressLine1 || '',
      addressLine2: customerAddress.addressLine2 || '',
      city: customerAddress.city || '',
      state: customerAddress.state || '',
      postalCode: customerAddress.postalCode || '',
      country: customerAddress.country || ''
    });
  }


  /// <summary>
  /// Resets the edit form and sets the isEditMode flag to false.
  /// </summary>
  /// <returns>
  /// void
  /// </returns>
  cancelEdit() {
    this.editForm.reset();
    this.isEditMode = false;
  }

  /// <summary>
  /// Deletes a customer address with the given id.
  /// </summary>
  /// <param name="id">The id of the customer address to delete.</param>
  /// <returns>
  /// Nothing.
  /// </returns>
  deleteCustomerAddress(id: number) {
    this.customerAddressService.deleteCustomerAddress(id).subscribe(() => {
      this.loadCustomerAddresses();
    });
  }
}
