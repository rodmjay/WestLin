import { Commodity } from '../enums/commodity.enum';
import { ICommodityRule } from '../interfaces/commodity-rule.interface';
import { IConstructionGroup } from '../interfaces/construction-group.interface';
import { IConstruction } from '../interfaces/construction.interface';
import { Construction } from './construction';

export class ConstructionGroup implements IConstructionGroup {
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
  commodityRuleCount: ICommodityRule[] = [];
  
  private static groupMap: Map<number, IConstructionGroup> = new Map();
  private static resourceMap: Map<string, IConstructionGroup> = new Map();
  
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
    this.resourceId = '';
    
    // Initialize commodity rules
    for (let stuff = Commodity.STUFF_INIT; stuff < Commodity.STUFF_COUNT; stuff++) {
      this.commodityRuleCount[stuff] = {
        maxload: 0,
        take: false,
        give: false
      };
    }
    
    // Add this construction group to the static maps
    ConstructionGroup.addConstructionGroup(this);
  }
  
  getCosts(): number {
    return this.cost * this.costMul;
  }
  
  isAllowedHere(x: number, y: number, msg: boolean): boolean {
    // Default implementation always returns true
    // Subclasses should override this method to implement specific placement rules
    return true;
  }
  
  placeItem(x: number, y: number): number {
    // Create a new construction and place it at the specified coordinates
    const construction = this.createConstruction();
    construction.place(x, y);
    this.count++;
    return 1; // Success
  }
  
  createConstruction(): IConstruction {
    // Default implementation creates a basic Construction
    // Subclasses should override this method to create specific construction types
    const construction = new Construction();
    construction.constructionGroup = this;
    construction.initialize();
    return construction;
  }
  
  getName(): string {
    return this.name;
  }
  
  // Static methods for managing construction groups
  
  static addConstructionGroup(constructionGroup: IConstructionGroup): void {
    if (!this.groupMap.has(constructionGroup.group)) {
      this.groupMap.set(constructionGroup.group, constructionGroup);
    } else {
      console.log(`Rejecting ${constructionGroup.name} as ${constructionGroup.group} from ConstructionGroup::groupMap`);
    }
  }
  
  static addResourceID(resID: string, constructionGroup: IConstructionGroup): void {
    if (!this.resourceMap.has(resID)) {
      constructionGroup.resourceId = resID;
      this.resourceMap.set(constructionGroup.resourceId, constructionGroup);
      // In a real implementation, we would create a new ResourceGroup here
    } else {
      console.log(`Rejecting ${constructionGroup.name} as ${constructionGroup.resourceId} from ConstructionGroup::resourceMap`);
    }
  }
  
  static clearGroupMap(): void {
    this.groupMap.clear();
  }
  
  static clearResourceMap(): void {
    this.resourceMap.clear();
  }
  
  static getConstructionGroup(group: number): IConstructionGroup | null {
    return this.groupMap.get(group) || null;
  }
  
  static countConstructionGroup(group: number): number {
    return this.groupMap.has(group) ? 1 : 0;
  }
}
