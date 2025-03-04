import { Commodity } from '../enums/commodity.enum';
import { IConstructionGroup } from './construction-group.interface';

export interface IConstruction {
  x: number;
  y: number;
  flags: number;
  commodityCount: number[];
  commodityProd: number[];
  commodityProdPrev: number[];
  commodityMaxProd: number[];
  commodityMaxCons: number[];
  constructionGroup: IConstructionGroup | null;
  neighbors: IConstruction[];
  partners: IConstruction[];
  
  update(): void;
  report(): void;
  animate(): void;
  initialize(): void;
  place(x: number, y: number): void;
  
  produceStuff(stuffId: Commodity, amount: number): number;
  consumeStuff(stuffId: Commodity, amount: number): number;
  levelStuff(stuffId: Commodity, amount: number): number;
  tellstuff(stuffId: Commodity, level: number): number;
  
  initResources(): void;
  resetProdCounters(): void;
  reportCommodities(): void;
  initializeCommodities(): void;
  bootstrapCommodities(percentage: number): void;
  
  detach(): void;
  deneighborize(): void;
  neighborize(): void;
  linkTo(other: IConstruction): void;
  trade(): void;
}
