import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './third-party-provider-portal.routing.module';
import { AppComponent } from './third-party-provider-portal.component';
import { ClaimDetailsComponent } from './components/claim-details/claim-details.component'
import { ClaimsListComponent } from './components/claims-list/claims-list.component';
import { ProviderDashboardComponent } from './components/provider-dashboard/provider-dashboard.component';
import { ClaimFormComponent } from '../customer-portal/components/shared/claim-form/claim-form.component';


@NgModule({
  declarations: [
    ClaimDetailsComponent,
    ClaimsListComponent,
    ProviderDashboardComponent,
    ClaimFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
