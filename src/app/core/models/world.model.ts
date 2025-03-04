import { MapTile } from '../interfaces/map-tile.interface';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class World {
  private sideLen: number;
  private mapTiles: MapTile[] = [];
  private _dirty: boolean = false;
  private _seed: number = 0;
  private _climate: number = 0;
  private _withoutTrees: boolean = false;
  
  constructor(mapLen: number = 100) {
    this.sideLen = mapLen;
    this.initializeMapTiles();
  }
  
  private initializeMapTiles(): void {
    // Initialize map tiles with default values
    for (let i = 0; i < this.sideLen * this.sideLen; i++) {
      this.mapTiles.push(this.createDefaultMapTile());
    }
  }
  
  private createDefaultMapTile(): MapTile {
    return {
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
  
  getTile(x: number, y: number): MapTile | null {
    if (this.isInside(x, y)) {
      return this.mapTiles[x + y * this.sideLen];
    }
    return null;
  }
  
  getTileByIndex(index: number): MapTile | null {
    if (this.isInsideIndex(index)) {
      return this.mapTiles[index];
    }
    return null;
  }
  
  isInside(x: number, y: number): boolean {
    return x >= 0 && x < this.sideLen && y >= 0 && y < this.sideLen;
  }
  
  isInsideIndex(index: number): boolean {
    return index >= 0 && index < this.sideLen * this.sideLen;
  }
  
  isBorder(x: number, y: number): boolean {
    return x === 0 || x === this.sideLen - 1 || y === 0 || y === this.sideLen - 1;
  }
  
  isBorderIndex(index: number): boolean {
    const x = index % this.sideLen;
    const y = Math.floor(index / this.sideLen);
    return this.isBorder(x, y);
  }
  
  getLength(): number {
    return this.sideLen;
  }
  
  setLength(newLen: number): void {
    this.sideLen = newLen;
    this.mapTiles = [];
    this.initializeMapTiles();
  }
  
  get dirty(): boolean {
    return this._dirty;
  }
  
  set dirty(value: boolean) {
    this._dirty = value;
  }
  
  get seed(): number {
    return this._seed;
  }
  
  set seed(value: number) {
    this._seed = value;
  }
  
  get climate(): number {
    return this._climate;
  }
  
  set climate(value: number) {
    this._climate = value;
  }
  
  get withoutTrees(): boolean {
    return this._withoutTrees;
  }
  
  set withoutTrees(value: boolean) {
    this._withoutTrees = value;
  }
}
