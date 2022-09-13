import {RunShop} from "./RunShop";

export interface DetailedRun {

  runId: number,
  location: string,
  deliveryDay: string,
  shops: RunShop[],

}
