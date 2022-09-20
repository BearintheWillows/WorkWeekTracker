import {Component, Input, OnInit} from '@angular/core';
import {RunShop} from "../_models/RunShop";
import {MatTableDataSource} from "@angular/material/table";
import {map, Observable} from "rxjs";
import {WeekDay} from "@angular/common";


@Component({
  selector   : 'app-table',
  templateUrl: './table.component.html',
  styleUrls  : ['./table.component.scss']
})
export class TableComponent implements OnInit {

  @Input() shop!: RunShop;
  displayedColumns: string[] = ['name', 'address1', 'address2', 'city', 'county', 'postcode', 'notes'];

  dataSource: any[] =[];

  constructor() {

  }

  ngOnInit(): void {

  }

  getShop(){
    if(this.shop) {
      this.dataSource.push(this.shop);
    }
    return this.dataSource




  }

  // dataSource$: Observable<MatTableDataSource<RunShop>> =
  //   this.shop.pipe(
  //     map(data => {
  //       const dataSource = new MatTableDataSource<RunShop>();
  //       dataSource.data = data;
  //       return dataSource;
  //
  //     }));


}
