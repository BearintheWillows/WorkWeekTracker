import {Component, Input, OnInit} from '@angular/core';
import {RunsService} from "../../_services/runs.service";
import {DetailedRun} from "../../_models/detailedRun";
import {switchMap} from "rxjs/operators";
import {ActivatedRoute, ParamMap, Router} from "@angular/router";
import {Observable} from "rxjs";
import {RunShop} from 'src/app/_models/RunShop';
import {WeekDay} from "@angular/common";
import {baseRun} from "../../_models/baseRun";


@Component({
  selector   : 'app-run-detail',
  templateUrl: './run-detail.component.html',
  styleUrls  : ['./run-detail.component.scss']
})
export class RunDetailComponent implements OnInit {

  detailedRun$!: Observable<DetailedRun>;
  runId!: string;
  location?: string | null;
  runShops: RunShop[] | undefined;
  dayOfWeek: string[] = [
    "Sunday", "Monday", "Tuesday",
    "Wednesday", "Thursday"
    , "Friday", "Saturday"];



  constructor(
    private runService: RunsService,
    private route: ActivatedRoute,
    private router: Router) {

  }


  ngOnInit(): void {

    this.loadData(this.dayOfWeek[0]);

  }


  loadData(day: string) {
    this.detailedRun$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) => {

        this.runId = params.get('id')!;
        this.location = params.get('location');


        return this.runService.getRunShopsById(this.runId, day)

      }))

  }

  goToRunList(runId: string) {
    this.router.navigate(['/runs', {id: runId}]);

  }


}
