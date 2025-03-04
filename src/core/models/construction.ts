import { Commodity } from '../enums/commodity.enum';
import { IConstruction } from '../interfaces/construction.interface';
import { IConstructionGroup } from '../interfaces/construction-group.interface';

export class Construction implements IConstruction {
  x: number = 0;
  y: number = 0;
  flags: number = 0;
  commodityCount: number[] = [];
  commodityProd: number[] = [];
  commodityProdPrev: number[] = [];
  commodityMaxProd: number[] = [];
  commodityMaxCons: number[] = [];
  constructionGroup: IConstructionGroup | null = null;
  neighbors: IConstruction[] = [];
  partners: IConstruction[] = [];
  
  constructor() {
    this.initialize();
  }
  
  initialize(): void {
    // Initialize commodity arrays
    for (let i = Commodity.STUFF_INIT; i < Commodity.STUFF_COUNT; i++) {
      this.commodityCount[i] = 0;
      this.commodityProd[i] = 0;
      this.commodityProdPrev[i] = 0;
      this.commodityMaxProd[i] = 0;
      this.commodityMaxCons[i] = 0;
    }
  }
  
  update(): void {
    // Default implementation does nothing
    // Subclasses should override this method
  }
  
  report(): void {
    // Default implementation does nothing
    // Subclasses should override this method
  }
  
  animate(): void {
    // Default implementation does nothing
    // Subclasses should override this method
  }
  
  place(x: number, y: number): void {
    this.x = x;
    this.y = y;
  }
  
  produceStuff(stuffId: Commodity, amount: number): number {
    this.commodityCount[stuffId] += amount;
    this.commodityProd[stuffId] += amount;
    return amount;
  }
  
  consumeStuff(stuffId: Commodity, amount: number): number {
    const available = this.commodityCount[stuffId];
    const consumed = Math.min(available, amount);
    
    this.commodityCount[stuffId] -= consumed;
    this.commodityProd[stuffId] -= consumed;
    
    return consumed;
  }
  
  levelStuff(stuffId: Commodity, amount: number): number {
    const diff = amount - this.commodityCount[stuffId];
    
    if (diff > 0) {
      this.produceStuff(stuffId, diff);
    } else if (diff < 0) {
      this.consumeStuff(stuffId, -diff);
    }
    
    return diff;
  }
  
  tellstuff(stuffId: Commodity, level: number): number {
    return this.commodityCount[stuffId];
  }
  
  initResources(): void {
    // Default implementation does nothing
    // Subclasses should override this method
  }
  
  resetProdCounters(): void {
    // Reset production counters
    for (let i = Commodity.STUFF_INIT; i < Commodity.STUFF_COUNT; i++) {
      this.commodityProdPrev[i] = this.commodityProd[i];
      this.commodityProd[i] = 0;
    }
  }
  
  reportCommodities(): void {
    // Default implementation does nothing
    // Subclasses should override this method
  }
  
  initializeCommodities(): void {
    // Initialize all commodities to 0
    for (let i = Commodity.STUFF_INIT; i < Commodity.STUFF_COUNT; i++) {
      this.commodityCount[i] = 0;
      this.commodityProd[i] = 0;
      this.commodityProdPrev[i] = 0;
      this.commodityMaxProd[i] = 0;
      this.commodityMaxCons[i] = 0;
    }
  }
  
  bootstrapCommodities(percentage: number): void {
    // Set all commodities except STUFF_WASTE to percentage
    for (let i = Commodity.STUFF_INIT; i < Commodity.STUFF_COUNT; i++) {
      if (i !== Commodity.STUFF_WASTE) {
        this.commodityCount[i] = percentage;
      }
    }
  }
  
  detach(): void {
    // Remove all references from world
    this.deneighborize();
  }
  
  deneighborize(): void {
    // Cancel all neighbors and partners mutually
    // Remove this construction from all neighbors' lists
    this.neighbors.forEach(neighbor => {
      const index = neighbor.neighbors.indexOf(this);
      if (index !== -1) {
        neighbor.neighbors.splice(index, 1);
      }
    });
    
    // Remove this construction from all partners' lists
    this.partners.forEach(partner => {
      const index = partner.partners.indexOf(this);
      if (index !== -1) {
        partner.partners.splice(index, 1);
      }
    });
    
    // Clear this construction's lists
    this.neighbors = [];
    this.partners = [];
  }
  
  neighborize(): void {
    // Add all neighbor connections once
    // This would be implemented in a real game to connect to adjacent constructions
  }
  
  linkTo(other: IConstruction): void {
    // Establish mutual connection to neighbor or partner
    if (!this.neighbors.includes(other)) {
      this.neighbors.push(other);
    }
    
    if (!other.neighbors.includes(this)) {
      other.neighbors.push(this);
    }
  }
  
  trade(): void {
    // Exchange commodities with neighbors
    // This would be implemented in a real game to handle resource trading
  }
}
