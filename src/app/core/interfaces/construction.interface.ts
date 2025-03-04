import { Commodity } from '../enums/commodity.enum';

export interface Construction {
  x: number;
  y: number;
  flags: number;
  commodityCount: number[];
  commodityProd: number[];
  commodityProdPrev: number[];
  commodityMaxProd: number[];
  commodityMaxCons: number[];
  
  update(): void;
  report(): void;
  animate(): void;
  initialize(): void;
  place(x: number, y: number): void;
  
  produceStuff(stuffId: Commodity, amount: number): number;
  consumeStuff(stuffId: Commodity, amount: number): number;
  levelStuff(stuffId: Commodity, amount: number): number;
  tellstuff(stuffId: Commodity, level: number): number;
}
