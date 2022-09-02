import { Component, OnInit } from '@angular/core';
import { Run } from '../../_models/run';

@Component({
  selector: 'app-run-list',
  templateUrl: './run-list.component.html',
  styleUrls: ['./run-list.component.scss']
})
export class RunListComponent implements OnInit {

  run: Run = {
    id: 1,
    location: "March"
  }

  constructor() { }

  ngOnInit(): void {

  }


}
