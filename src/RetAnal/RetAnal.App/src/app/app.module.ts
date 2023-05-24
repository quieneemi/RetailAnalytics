import {HttpClientModule} from '@angular/common/http';
import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from "./app-routing.module";
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatListModule} from "@angular/material/list";
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatButtonModule} from "@angular/material/button";
import {MatPaginatorModule} from "@angular/material/paginator";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatDialogModule} from "@angular/material/dialog";
import {MatExpansionModule} from "@angular/material/expansion";
import {MatSnackBarModule} from "@angular/material/snack-bar";
import {MatMenuModule} from "@angular/material/menu";
import {MatProgressBarModule} from "@angular/material/progress-bar";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";

import {AppComponent} from './app.component';
import {TableListComponent} from './tables/table-list/table-list.component';
import {TableDetailsComponent} from './tables/table-details/table-details.component';
import {LoginComponent} from './auth/login/login.component';
import {EditDialogComponent} from './tables/edit-dialog/edit-dialog.component';
import {OfferListComponent} from './offers/offer-list/offer-list.component';
import {HomePageComponent} from './home-page/home-page.component';
import {ProfileComponent} from './auth/profile/profile.component';
import {AboutPageComponent} from './about-page/about-page.component';
import {OfferResultComponent} from './offers/offer-result/offer-result.component';

@NgModule({
  declarations: [
    AppComponent,
    TableListComponent,
    TableDetailsComponent,
    LoginComponent,
    EditDialogComponent,
    OfferListComponent,
    HomePageComponent,
    ProfileComponent,
    AboutPageComponent,
    OfferResultComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatListModule,
    MatToolbarModule,
    MatButtonModule,
    MatPaginatorModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    MatExpansionModule,
    FormsModule,
    MatSnackBarModule,
    MatMenuModule,
    MatProgressBarModule,
    MatProgressSpinnerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
