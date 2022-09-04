import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {RunListComponent} from "./Runs/run-list/run-list.component";

const routes: Routes = [
  { path: 'runs', component: RunListComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
