import {RunShop} from "./RunShop";
import {baseRun} from "./baseRun";

export interface DetailedRun extends baseRun {

  deliveryDay: string,
  shops: RunShop[],

}
