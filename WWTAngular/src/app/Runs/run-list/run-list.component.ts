import {Component, OnInit} from '@angular/core';
import {RunsService} from "../../_services/runs.service";
import {baseRun} from "../../_models/baseRun";
import {MessageService} from "../../_services/message.service";
import {Observable, switchMap} from "rxjs";
import {ActivatedRoute, ParamMap, Router} from "@angular/router";
import {DetailedRun} from "../../_models/detailedRun";

@Component({
  selector   : 'app-run-list',
  templateUrl: './run-list.component.html',
  styleUrls  : ['./run-list.component.scss']
})
export class RunListComponent implements OnInit {

  runs$: Observable<baseRun[]> | undefined;

  constructor(
    private runService: RunsService,
    private messageService: MessageService,
    private route: ActivatedRoute,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.loadData()
  }


  loadData() {

   this.runs$ = this.runService.getRuns();
  }

  goToDetail(run: baseRun) {
    const runId = run ? run.id : null;
    const runLoc = run ? run.location : null;
    this.router.navigate(['/run/' + run.id + '/details', {id: runId, location: runLoc}]);

  }

}
