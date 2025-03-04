import { Construction } from '../interfaces/construction.interface';
import { Commodity } from '../enums/commodity.enum';
import { Injectable } from '@angular/core';

@Injectable()
export class ConstructionBase implements Construction {
  x: number = 0;
  y: number = 0;
  flags: number = 0;
  commodityCount: number[] = new Array(Commodity.STUFF_COUNT).fill(0);
  commodityProd: number[] = new Array(Commodity.STUFF_COUNT).fill(0);
  commodityProdPrev: number[] = new Array(Commodity.STUFF_COUNT).fill(0);
  commodityMaxProd: number[] = new Array(Commodity.STUFF_COUNT).fill(0);
  commodityMaxCons: number[] = new Array(Commodity.STUFF_COUNT).fill(0);
  
  constructor() {
    this.initializeCommodities();
  }
  
  update(): void {
    // To be implemented by derived classes
  }
  
  report(): void {
    // To be implemented by derived classes
  }
  
  animate(): void {
    // Optional implementation by derived classes
  }
  
  initialize(): void {
    // Optional initialization for new constructions
  }
  
  place(x: number, y: number): void {
    this.x = x;
    this.y = y;
  }
  
  initializeCommodities(): void {
    for (let i = Commodity.STUFF_INIT; i < Commodity.STUFF_COUNT; i++) {
      this.commodityCount[i] = 0;
      this.commodityProd[i] = 0;
      this.commodityProdPrev[i] = 0;
      this.commodityMaxProd[i] = 0;
      this.commodityMaxCons[i] = 0;
    }
  }
  
  produceStuff(stuffId: Commodity, amount: number): number {
    this.commodityCount[stuffId] += amount;
    this.commodityProd[stuffId] += amount;
    return amount;
  }
  
  consumeStuff(stuffId: Commodity, amount: number): number {
    const available = Math.min(this.commodityCount[stuffId], amount);
    this.commodityCount[stuffId] -= available;
    this.commodityProd[stuffId] -= available;
    return available;
  }
  
  levelStuff(stuffId: Commodity, amount: number): number {
    const diff = amount - this.commodityCount[stuffId];
    this.commodityCount[stuffId] = amount;
    this.commodityProd[stuffId] += diff;
    return diff;
  }
  
  tellstuff(stuffId: Commodity, level: number): number {
    return this.commodityCount[stuffId];
  }
}
