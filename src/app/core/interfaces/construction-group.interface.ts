import { Construction } from './construction.interface';
import { CommodityRule } from './commodity-rule.interface';

export interface ConstructionGroup {
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
  commodityRuleCount: CommodityRule[];
  
  getCosts(): number;
  isAllowedHere(x: number, y: number, msg: boolean): boolean;
  placeItem(x: number, y: number): number;
  createConstruction(): Construction;
  getName(): string;
}
