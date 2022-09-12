import {WeekDay} from "@angular/common";
import {Shop} from "./shop";
import {RunShop} from "./RunShop";

export interface DailyRoute{

  runId: number,
  location: string,
  deliveryDay: string,
  shops: RunShop[],

}
