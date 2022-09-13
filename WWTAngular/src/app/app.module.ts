import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './routing-modules/app-routing.module';
import { AppComponent } from './app.component';
import {RunListComponent} from "./Runs/run-list/run-list.component";
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSliderModule} from "@angular/material/slider";
import {MatListModule} from "@angular/material/list";
import {RunDetailComponent} from "./Runs/run-detail/run-detail.component";
import { MessagesComponent } from './messages/messages.component';
import { NavComponent } from './nav/nav.component';
import {MatToolbarModule} from "@angular/material/toolbar";
import { DashboardComponent } from './dashboard/dashboard.component';
import { FooterComponent } from './footer/footer.component';
import {MatButtonModule} from "@angular/material/button";
import {MatTabsModule} from "@angular/material/tabs";
import {MatCardModule} from "@angular/material/card";
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import {RunsModule} from "./Runs/runs.module";

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    DashboardComponent,
    FooterComponent,
    PageNotFoundComponent,
    MessagesComponent

  ],
    imports: [
        BrowserModule,
        HttpClientModule,
        BrowserAnimationsModule,
        MatToolbarModule,
        RunsModule,
        AppRoutingModule,

    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
