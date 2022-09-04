import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
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

@NgModule({
  declarations: [
    AppComponent,
    RunListComponent,
    RunDetailComponent,
    MessagesComponent,
    NavComponent,
    DashboardComponent,
    FooterComponent,


  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatSliderModule,
    MatListModule,
    MatToolbarModule,
    MatButtonModule,
    MatTabsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
