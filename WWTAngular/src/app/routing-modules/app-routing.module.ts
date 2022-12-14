import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {PageNotFoundComponent} from "../page-not-found/page-not-found.component";

const appRoutes: Routes = [

//Default Route
  { path: '', redirectTo: '/runs', pathMatch: 'full'},
// WildCard
  { path: '**', component: PageNotFoundComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
