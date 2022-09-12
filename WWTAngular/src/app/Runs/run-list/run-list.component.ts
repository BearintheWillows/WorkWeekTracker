import {Component, OnInit, Input} from '@angular/core';
import {Run} from '../../_models/run';
import {RunsService} from "../../_services/runs.service";
import {MessageService} from "../../_services/message.service";

@Component({
  selector   : 'app-run-list',
  templateUrl: './run-list.component.html',
  styleUrls  : ['./run-list.component.scss']
})
export class RunListComponent implements OnInit {

  runs?: any;
  selectedRun?: Run

  constructor(private runService: RunsService, private messageService: MessageService) {
  }

  ngOnInit(): void {
    this.loadData()
  }


  loadData() {
    this.runService.getRuns().subscribe(res => {
      this.runs = res;
      console.log(res)
    });
  }
  onSelect(run: Run): void{
    this.selectedRun = run;
    console.log(`selectedRun: ${run.id}`)

  }

  onRemoveSelect(): void{
    this.selectedRun = undefined;

  }


}
