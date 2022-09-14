import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RunListComponent} from "./run-list/run-list.component";
import {RunDetailComponent} from "./run-detail/run-detail.component";
import {RunsRoutingModule} from "../routing-modules/runs-routing.module";
import {FormsModule} from "@angular/forms";
import {MatCardModule} from "@angular/material/card";
import {MatButtonModule} from "@angular/material/button";


@NgModule({
  declarations: [
    RunListComponent,
    RunDetailComponent

  ],
    imports: [
        CommonModule,
        RunsRoutingModule,
        FormsModule,
        MatCardModule,
        MatButtonModule,

    ],
})
export class RunsModule { }
