import {Component, OnInit, Input, EventEmitter, Output} from '@angular/core';
import { Run } from '../../_models/run';
import {RunsService} from "../../_services/runs.service";
import {DailyRoute} from "../../_models/dailyRoute";
import {Shop} from "../../_models/shop";
import {Observable, of} from "rxjs";
import {RunShop} from "../../_models/RunShop";

@Component({
  selector: 'app-run-detail',
  templateUrl: './run-detail.component.html',
  styleUrls: ['./run-detail.component.scss']
})
export class RunDetailComponent implements OnInit {

  dailyRoute?: DailyRoute ;
  route: RunShop[] = [];

  constructor(private runService: RunsService) { }
  @Input() run?: any;


  ngOnInit(): void {
    this.loadData();
  }

  getDetail(): void{
    this.loadData();
    this.displayData();
  }


  loadData(): void {
    this.runService.getRunShopsById(1).subscribe((res) => {
      this.dailyRoute = res;
      this.route = res.shops;
    });
  }


  displayData(): void{
    console.log(this.route)

  }


}
