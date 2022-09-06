import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {RunListComponent} from "./Runs/run-list/run-list.component";
import {RunDetailComponent} from "./Runs/run-detail/run-detail.component";

const routes: Routes = [
  { path: 'runs', component: RunListComponent},
  { path: 'run/:id/details', component: RunDetailComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
