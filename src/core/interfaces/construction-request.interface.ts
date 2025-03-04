import { IConstruction } from './construction.interface';

export interface IConstructionRequest {
  subject: IConstruction;
  execute(): void;
}
