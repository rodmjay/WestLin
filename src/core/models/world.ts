import { IMapTile } from '../interfaces/map-tile.interface';
import { IGround } from '../interfaces/ground.interface';

export class World {
  private mapTiles: IMapTile[][] = [];
  private sideLen: number = 100; // Default size
  
  constructor(sideLen: number = 100) {
    this.sideLen = sideLen;
    this.initializeMap();
  }
  
  private initializeMap(): void {
    // Initialize the map with empty tiles
    this.mapTiles = [];
    for (let y = 0; y < this.sideLen; y++) {
      this.mapTiles[y] = [];
      for (let x = 0; x < this.sideLen; x++) {
        this.mapTiles[y][x] = this.createEmptyTile();
      }
    }
  }
  
  private createEmptyTile(): IMapTile {
    // Create an empty tile with default values
    return {
      ground: this.createEmptyGround(),
      construction: null,
      reportingConstruction: null,
      type: 0,
      group: 0,
      flags: 0,
      coal_reserve: 0,
      ore_reserve: 0,
      pollution: 0
    };
  }
  
  private createEmptyGround(): IGround {
    return {
      altitude: 0,
      ecotable: 0,
      wastes: 0,
      pollution: 0,
      water_alt: 0,
      water_pol: 0,
      water_wast: 0,
      water_next: 0,
      int1: 0,
      int2: 0,
      int3: 0,
      int4: 0
    };
  }
  
  getTile(x: number, y: number): IMapTile | null {
    if (this.isInside(x, y)) {
      return this.mapTiles[y][x];
    }
    return null;
  }
  
  setTile(x: number, y: number, tile: IMapTile): boolean {
    if (this.isInside(x, y)) {
      this.mapTiles[y][x] = tile;
      return true;
    }
    return false;
  }
  
  isInside(x: number, y: number): boolean {
    return x >= 0 && x < this.sideLen && y >= 0 && y < this.sideLen;
  }
  
  isBorder(x: number, y: number): boolean {
    return this.isInside(x, y) && (x === 0 || x === this.sideLen - 1 || y === 0 || y === this.sideLen - 1);
  }
  
  getLength(): number {
    return this.sideLen;
  }
  
  // Additional methods for world manipulation
  
  setConstruction(x: number, y: number, construction: any): boolean {
    const tile = this.getTile(x, y);
    if (tile) {
      tile.construction = construction;
      return true;
    }
    return false;
  }
  
  removeConstruction(x: number, y: number): boolean {
    const tile = this.getTile(x, y);
    if (tile && tile.construction) {
      tile.construction = null;
      return true;
    }
    return false;
  }
  
  // Methods for finding specific areas or checking conditions
  
  findBareArea(x: number, y: number, size: number): { x: number, y: number } | null {
    // Find a bare area of the specified size near the given coordinates
    // This is a simplified implementation
    for (let searchY = Math.max(0, y - 10); searchY < Math.min(this.sideLen, y + 10); searchY++) {
      for (let searchX = Math.max(0, x - 10); searchX < Math.min(this.sideLen, x + 10); searchX++) {
        if (this.isBareArea(searchX, searchY, size)) {
          return { x: searchX, y: searchY };
        }
      }
    }
    return null;
  }
  
  isBareArea(x: number, y: number, size: number): boolean {
    // Check if the area starting at (x, y) with the given size is bare
    // (i.e., has no constructions)
    if (x + size > this.sideLen || y + size > this.sideLen) {
      return false;
    }
    
    for (let checkY = y; checkY < y + size; checkY++) {
      for (let checkX = x; checkX < x + size; checkX++) {
        const tile = this.getTile(checkX, checkY);
        if (!tile || tile.construction) {
          return false;
        }
      }
    }
    
    return true;
  }
  
  // Methods for simulation
  
  updateWorld(): void {
    // Update all tiles in the world
    // This would be called during the simulation step
    for (let y = 0; y < this.sideLen; y++) {
      for (let x = 0; x < this.sideLen; x++) {
        const tile = this.getTile(x, y);
        if (tile && tile.construction) {
          tile.construction.update();
        }
      }
    }
  }
  
  animateWorld(): void {
    // Animate all constructions in the world
    // This would be called during the animation step
    for (let y = 0; y < this.sideLen; y++) {
      for (let x = 0; x < this.sideLen; x++) {
        const tile = this.getTile(x, y);
        if (tile && tile.construction) {
          tile.construction.animate();
        }
      }
    }
  }
}
