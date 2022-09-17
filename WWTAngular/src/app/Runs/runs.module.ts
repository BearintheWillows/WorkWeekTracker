import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RunListComponent} from "./run-list/run-list.component";
import {RunDetailComponent} from "./run-detail/run-detail.component";
import {RunsRoutingModule} from "../routing-modules/runs-routing.module";
import {FormsModule} from "@angular/forms";
import {MatCardModule} from "@angular/material/card";
import {MatExpansionModule} from "@angular/material/expansion";
import {AppModule} from "../app.module";
import {TableComponent} from "../table/table.component";
import {TAB} from "@angular/cdk/keycodes";
import {MatTableModule} from "@angular/material/table";


@NgModule({
  declarations: [
    RunListComponent,
    RunDetailComponent,
    TableComponent
  ],
  imports: [
    CommonModule,
    RunsRoutingModule,
    FormsModule,
    MatCardModule,
    MatExpansionModule,
    MatTableModule,


  ],
})
export class RunsModule { }
