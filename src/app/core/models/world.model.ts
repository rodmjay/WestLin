import { Injectable } from '@angular/core';
import { MapTile } from '../interfaces/map-tile.interface';

@Injectable({
  providedIn: 'root'
})
export class World {
  private mapTiles: MapTile[][] = [];
  private mapLength: number;

  constructor() {
    this.mapLength = 100;
    this.initializeMap();
  }

  private initializeMap(): void {
    // Initialize the map with empty tiles
    for (let y = 0; y < this.mapLength; y++) {
      this.mapTiles[y] = [];
      for (let x = 0; x < this.mapLength; x++) {
        this.mapTiles[y][x] = {
          ground: {
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
          },
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
    }
  }

  getLength(): number {
    return this.mapLength;
  }

  isInside(x: number, y: number): boolean {
    return x >= 0 && y >= 0 && x < this.mapLength && y < this.mapLength;
  }

  isBorder(x: number, y: number): boolean {
    return this.isInside(x, y) && (x === 0 || y === 0 || x === this.mapLength - 1 || y === this.mapLength - 1);
  }

  getTile(x: number, y: number): MapTile | null {
    if (this.isInside(x, y)) {
      return this.mapTiles[y][x];
    }
    return null;
  }
}
