import {NgModule} from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import {LoginComponent} from "./auth/login/login.component";
import {TableListComponent} from "./tables/table-list/table-list.component";
import {TableDetailsComponent} from "./tables/table-details/table-details.component";
import {OfferListComponent} from "./offers/offer-list/offer-list.component";
import {HomePageComponent} from "./home-page/home-page.component";
import {authGuard, adminGuard} from "./auth/auth.guard";
import {AboutPageComponent} from "./about-page/about-page.component";

const routes: Routes = [
  {path: '', component: HomePageComponent, canActivate: [authGuard]},
  {path: 'login', component: LoginComponent},
  {path: 'tables', component: TableListComponent, canActivate: [authGuard]},
  {path: 'tables/:tableName', component: TableDetailsComponent, canActivate: [authGuard]},
  {path: 'offers', component: OfferListComponent, canActivate: [adminGuard]},
  {path: 'about', component: AboutPageComponent},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
