import {Component, OnInit} from '@angular/core';
import {RunsService} from "../../_services/runs.service";
import {DetailedRun} from "../../_models/detailedRun";
import {switchMap} from "rxjs/operators";
import {ActivatedRoute, ParamMap, Router} from "@angular/router";
import {Observable} from "rxjs";
import {RunShop} from 'src/app/_models/RunShop';


@Component({
  selector   : 'app-run-detail',
  templateUrl: './run-detail.component.html',
  styleUrls  : ['./run-detail.component.scss']
})
export class RunDetailComponent implements OnInit {

  detailedRun$!: Observable<DetailedRun>;
  runId?: string | null;
  day?: string | null;
  runShops!: RunShop[];



  constructor(
    private runService: RunsService,
    private route: ActivatedRoute,
    private router: Router) {

  }


  ngOnInit(): void {

    this.loadData();

  }

  loadData() {
    this.detailedRun$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) => {

        this.runId = params.get('id');
        this.day = params.get('day');

        return this.runService.getRunShopsById(this.runId, this.day)

      }))

    this.detailedRun$.subscribe(x => {
      this.runShops = x.shops
      console.log(this.runShops)
    })
  }

  goToRunList(run: DetailedRun) {
    const runId = run ? run.id : null;
    this.router.navigate(['/runs', {id: runId, foo: 'foo'}]);

  }


}
