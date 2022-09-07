import {Component, OnInit, Input, EventEmitter, Output} from '@angular/core';
import { Run } from '../../_models/run';
import {RunsService} from "../../_services/runs.service";
import {DailyRoute} from "../../_models/dailyRoute";

@Component({
  selector: 'app-run-detail',
  templateUrl: './run-detail.component.html',
  styleUrls: ['./run-detail.component.scss']
})
export class RunDetailComponent implements OnInit {

  dailyRoute?: DailyRoute;
  constructor(private runService: RunsService) { }
  @Input() run?: Run;


  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    let runId = this.run?.id;
    this.runService.getRunShopsById(68).subscribe(res => {
      this.dailyRoute = res;
      console.log(res)
    });
  }



}
