import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './customer-portal.routing.module';
import { AppComponent } from './customer-portal.component';
import { ClaimDetailsComponent } from './components/claim-details/claim-details.component';
import { ClaimListComponent } from './components/claim-list/claim-list.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EditProfileComponent } from './components/edit-profile/edit-profile.component';
import { NewClaimComponent } from './components/new-claim/new-claim.component';
import { ClaimFormComponent } from './components/shared/claim-form/claim-form.component';
import { ClaimSummaryComponent } from './components/shared/claim-summary/claim-summary.component';


@NgModule({
  declarations: [
    ClaimDetailsComponent,
    ClaimListComponent,
    DashboardComponent,
    EditProfileComponent,
    NewClaimComponent,
    ClaimFormComponent,
    ClaimSummaryComponent
    ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
