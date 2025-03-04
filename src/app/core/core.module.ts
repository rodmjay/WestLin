import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CityStateService } from './services/city-state.service';
import { SimulationService } from './services/simulation.service';
import { ConstructionManagerService } from './services/construction-manager.service';
import { World } from './models/world.model';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    CityStateService,
    SimulationService,
    ConstructionManagerService,
    World
  ]
})
export class CoreModule { }
