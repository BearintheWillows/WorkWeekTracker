import {Component, OnInit, Input} from '@angular/core';
import {Run} from '../../_models/run';
import {RunsService} from "../../_services/runs.service";

@Component({
  selector   : 'app-run-list',
  templateUrl: './run-list.component.html',
  styleUrls  : ['./run-list.component.scss']
})
export class RunListComponent implements OnInit {

  runs?: any;
  selectedRun?: Run

  constructor(private runService: RunsService) {
  }

  ngOnInit(): void {
    this.loadData()
  }

  onSelect(run: Run): void {
    this.selectedRun = run;

  }

  loadData() {
    this.runService.getRuns().subscribe(res => {
      this.runs = res;
      console.log(res)
    });
  }
}
