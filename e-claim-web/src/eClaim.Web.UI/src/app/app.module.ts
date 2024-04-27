import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { CustomerAddressListComponent } from '../app/customer-portal/components/customer-address-list/customer-address-list.component';


@NgModule({
  declarations: [AppComponent, CustomerAddressListComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule 
  ],
  providers: [],
  bootstrap: [CustomerAddressListComponent]
})
export class AppModule { }
