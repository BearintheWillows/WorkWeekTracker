import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {RunDetailComponent} from "../Runs/run-detail/run-detail.component";
import {RunListComponent} from "../Runs/run-list/run-list.component";

const runsRoutes: Routes = [

  {
    path: 'runs', component: RunListComponent,
    data: {animation: 'runs'}
  },
  {
    path: 'run/:id/details', component: RunDetailComponent,
    data: {animation: 'run'}
  },

];


@NgModule({
  imports: [RouterModule.forChild(runsRoutes)],
  exports: [RouterModule]
})
export class RunsRoutingModule {
}
