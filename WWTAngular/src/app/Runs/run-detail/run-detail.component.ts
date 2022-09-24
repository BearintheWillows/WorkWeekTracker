import {Component, Input, OnInit} from '@angular/core';
import {RunsService} from "../../_services/runs.service";
import {DetailedRun} from "../../_models/detailedRun";
import {finalize, switchMap} from "rxjs/operators";
import {ActivatedRoute, ParamMap, Router} from "@angular/router";
import {Observable, Subscription} from "rxjs";
import {RunShop} from 'src/app/_models/RunShop';

@Component({
  selector   : 'app-run-detail',
  templateUrl: './run-detail.component.html',
  styleUrls  : ['./run-detail.component.scss']
})
export class RunDetailComponent implements OnInit {

  detailedRun$!: Observable<DetailedRun>;
  runId: string = '';
  runLocation: string = '';
  deliveryDay: string = 'Monday';
  run?: DetailedRun;
  dayOfWeek: string[] = [
    "Sunday", "Monday", "Tuesday",
    "Wednesday", "Thursday"
    , "Friday", "Saturday"];
  dataLoaded: boolean = false;


  constructor(
    private runService: RunsService,
    private route: ActivatedRoute,
    private router: Router,) {

  }


  ngOnInit(): void {
    this.loadData('Sunday')

  }


  loadData(day: string) {
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) => {

        this.runId = params.get('id')!;
        this.runLocation = params.get('loc')!;

        return this.runService.getRunShopsById(this.runId, day)
      })
    ).subscribe(x => {

      this.run = x;
      if(this.run) {
        this.dataLoaded = true;
      } else {
        this.dataLoaded = false;

      }
      console.log(`Data Loaded: ${this.dataLoaded}.`)
      console.log(`Run Data: ${this.run}`)
    })

  }


  goToRunList(runId: string) {
    this.router.navigate(['/runs', {id: runId}]);

  }


}
