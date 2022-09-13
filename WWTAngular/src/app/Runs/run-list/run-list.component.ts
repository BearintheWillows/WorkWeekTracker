import {Component, OnInit} from '@angular/core';
import {RunsService} from "../../_services/runs.service";
import {baseRun} from "../../_models/baseRun";

@Component({
  selector   : 'app-run-list',
  templateUrl: './run-list.component.html',
  styleUrls  : ['./run-list.component.scss']
})
export class RunListComponent implements OnInit {

  runs: baseRun[] = [];
  selectedRun?: baseRun;
  runId: string = '';

  constructor(
    private runService: RunsService,
    ) {
  }

  ngOnInit(): void {
    this.loadData()
  }


  loadData() {

    this.runService.getRuns().subscribe(res => {
      this.runs = res;
    });
  }
  onSelect(run: baseRun): void{
    this.selectedRun = run;

  }

  onRemoveSelect(): void{
    this.selectedRun = undefined;

  }


}
