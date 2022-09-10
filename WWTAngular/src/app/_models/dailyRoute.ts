import {WeekDay} from "@angular/common";
import {Shop} from "./shop";

export interface DailyRoute{

  runId: number;
  shops: Shop[];
  day: WeekDay;


}
