import { Component, OnInit } from '@angular/core';
import { Run } from '../../_models/run';

@Component({
  selector: 'app-run-list',
  templateUrl: './run-list.component.html',
  styleUrls: ['./run-list.component.scss']
})
export class RunListComponent implements OnInit {

  runs: Run[];

  constructor() { }

  ngOnInit(): void {

  }


}
