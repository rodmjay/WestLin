import { Injectable } from '@angular/core';
import { ConstructionManagerService } from './core/services/construction-manager.service';
import { SimulationService } from './core/services/simulation.service';

@Injectable({
  providedIn: 'root'
})
export class TestImports {
  constructor(
    private constructionManager: ConstructionManagerService,
    private simulationService: SimulationService
  ) {}
}
