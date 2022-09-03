import { Component, OnInit, Input } from '@angular/core';
import { Run } from '../../_models/run';

@Component({
  selector: 'app-run-detail',
  templateUrl: './run-detail.component.html',
  styleUrls: ['./run-detail.component.scss']
})
export class RunDetailComponent implements OnInit {

  @Input() run?: Run;

  constructor() { }

  ngOnInit(): void {
  }

}
