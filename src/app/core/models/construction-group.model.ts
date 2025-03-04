import { ConstructionGroup } from '../interfaces/construction-group.interface';
import { Construction } from '../interfaces/construction.interface';
import { CommodityRule } from '../interfaces/commodity-rule.interface';
import { Commodity } from '../enums/commodity.enum';
import { Injectable } from '@angular/core';

@Injectable()
export class ConstructionGroupBase implements ConstructionGroup {
  name: string = '';
  noCredit: boolean = false;
  group: number = 0;
  size: number = 1;
  colour: number = 0;
  costMul: number = 1;
  bulCost: number = 0;
  fireChance: number = 0;
  cost: number = 0;
  tech: number = 0;
  range: number = 0;
  mpsPages: number = 0;
  count: number = 0;
  commodityRuleCount: CommodityRule[] = new Array(Commodity.STUFF_COUNT).fill(null).map(() => ({
    maxload: 0,
    take: false,
    give: false
  }));
  
  constructor(
    name: string,
    noCredit: boolean,
    group: number,
    size: number,
    colour: number,
    costMul: number,
    bulCost: number,
    fireChance: number,
    cost: number,
    tech: number,
    range: number,
    mpsPages: number
  ) {
    this.name = name;
    this.noCredit = noCredit;
    this.group = group;
    this.size = size;
    this.colour = colour;
    this.costMul = costMul;
    this.bulCost = bulCost;
    this.fireChance = fireChance;
    this.cost = cost;
    this.tech = tech;
    this.range = range;
    this.mpsPages = mpsPages;
    this.count = 0;
    
    // Initialize commodity rules
    for (let stuff = Commodity.STUFF_INIT; stuff < Commodity.STUFF_COUNT; stuff++) {
      this.commodityRuleCount[stuff] = {
        maxload: 0,
        take: false,
        give: false
      };
    }
  }
  
  getCosts(): number {
    return this.cost;
  }
  
  isAllowedHere(x: number, y: number, msg: boolean): boolean {
    // Default implementation, to be overridden by derived classes
    return true;
  }
  
  placeItem(x: number, y: number): number {
    // Default implementation, to be overridden by derived classes
    return 0;
  }
  
  createConstruction(): Construction {
    // This method must be implemented by derived classes
    throw new Error('Method not implemented. Must be overridden by derived classes.');
  }
  
  getName(): string {
    return this.name;
  }
}
