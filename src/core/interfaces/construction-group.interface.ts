import { Commodity } from '../enums/commodity.enum';
import { ICommodityRule } from './commodity-rule.interface';
import { IConstruction } from './construction.interface';

export interface IConstructionGroup {
  name: string;
  noCredit: boolean;
  group: number;
  size: number;
  colour: number;
  costMul: number;
  bulCost: number;
  fireChance: number;
  cost: number;
  tech: number;
  range: number;
  mpsPages: number;
  count: number;
  resourceId: string;
  commodityRuleCount: ICommodityRule[];
  
  getCosts(): number;
  isAllowedHere(x: number, y: number, msg: boolean): boolean;
  placeItem(x: number, y: number): number;
  createConstruction(): IConstruction;
  getName(): string;
}
