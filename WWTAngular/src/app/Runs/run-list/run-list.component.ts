import {Component, OnInit, Input} from '@angular/core';
import {Run} from '../../_models/run';
import {RunsService} from "../../_services/runs.service";
import {MessageService} from "../../_services/message.service";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector   : 'app-run-list',
  templateUrl: './run-list.component.html',
  styleUrls  : ['./run-list.component.scss']
})
export class RunListComponent implements OnInit {

  runs: Run[] = [];
  selectedRun?: Run;
  runId: string = '';

  constructor(
    private runService: RunsService,
    ) {
  }

  ngOnInit(): void {
    this.runs = this.route
    this.loadData()
  }


  loadData() {

    this.runService.getRuns().subscribe(res => {
      this.runs = res;
    });
  }
  onSelect(run: Run): void{
    this.selectedRun = run;

  }

  onRemoveSelect(): void{
    this.selectedRun = undefined;

  }


}
