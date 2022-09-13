import {Component, OnInit, Input, EventEmitter, Output} from '@angular/core';
import { Run } from '../../_models/run';
import {RunsService} from "../../_services/runs.service";
import {DetailedRun} from "../../_models/detailedRun";
import {Shop} from "../../_models/shop";
import {Observable, of, switchMap} from "rxjs";
import {RunShop} from "../../_models/RunShop";
import {ActivatedRoute, ParamMap, Router} from "@angular/router";

@Component({
  selector: 'app-run-detail',
  templateUrl: './run-detail.component.html',
  styleUrls: ['./run-detail.component.scss']
})
export class RunDetailComponent implements OnInit {

  detailedRun: DetailedRun | undefined ;


  constructor(
    private runService: RunsService,
    private route: ActivatedRoute,
    private router: Router) {

  }



  ngOnInit(): void {
    this.detailedRun = this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
      this.runService.getRunShopsById(params.get('id')!))

    )
  }

  goToRunList(detailedRun: DetailedRun) {

    const runId = detailedRun ? detailedRun.runId : null ;
    this.router.navigate(['/runs', { id: runId, foo: 'foo'}]);

  }






}
