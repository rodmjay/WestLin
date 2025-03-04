import { Ground } from './ground.interface';
import { Construction } from './construction.interface';

export interface MapTile {
  ground: Ground;
  construction: Construction | null;
  reportingConstruction: Construction | null;
  type: number;
  group: number;
  flags: number;
  coal_reserve: number;
  ore_reserve: number;
  pollution: number;
}
