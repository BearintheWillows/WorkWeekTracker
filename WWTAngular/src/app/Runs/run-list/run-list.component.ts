import {Component, OnInit} from '@angular/core';
import {RunsService} from "../../_services/runs.service";
import {baseRun} from "../../_models/baseRun";
import {MessageService} from "../../_services/message.service";
import {Observable, switchMap} from "rxjs";
import {ActivatedRoute, ParamMap} from "@angular/router";

@Component({
  selector   : 'app-run-list',
  templateUrl: './run-list.component.html',
  styleUrls  : ['./run-list.component.scss']
})
export class RunListComponent implements OnInit {

  runs!: baseRun[];
  selectedId = 0;

  constructor(
    private runService: RunsService,
    private messageService: MessageService,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit(): void {
    this.loadData()
  }


  loadData() {

   this.runService.getRuns().subscribe(x =>{
   this.runs = x;

   });
  }


}
