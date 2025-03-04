import { IGround } from './ground.interface';
import { IConstruction } from './construction.interface';

export interface IMapTile {
  ground: IGround;
  construction: IConstruction | null;
  reportingConstruction: IConstruction | null;
  type: number;
  group: number;
  flags: number;
  coal_reserve: number;
  ore_reserve: number;
  pollution: number;
}
