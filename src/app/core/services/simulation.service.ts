import { Injectable } from '@angular/core';
import { CityStateService } from './city-state.service';
import { World } from '../models/world.model';
import { ConstructionManagerService } from './construction-manager.service';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SimulationService {
  private _isRunning = new BehaviorSubject<boolean>(false);
  private _speed = new BehaviorSubject<number>(1);
  private simulationInterval: any;
  private readonly NUMOF_DAYS_IN_MONTH = 100;
  private readonly NUMOF_DAYS_IN_YEAR = 1200; // 12 * NUMOF_DAYS_IN_MONTH
  
  constructor(
    private cityStateService: CityStateService,
    private world: World,
    private constructionManager: ConstructionManagerService
  ) {}
  
  get isRunning(): Observable<boolean> {
    return this._isRunning.asObservable();
  }
  
  get speed(): Observable<number> {
    return this._speed.asObservable();
  }
  
  setSpeed(value: number): void {
    this._speed.next(value);
    if (this._isRunning.value) {
      this.stop();
      this.start();
    }
  }
  
  start(): void {
    if (!this._isRunning.value) {
      const interval = 1000 / this._speed.value;
      this.simulationInterval = setInterval(() => {
        this.doTimeStep();
      }, interval);
      this._isRunning.next(true);
    }
  }
  
  stop(): void {
    if (this._isRunning.value) {
      clearInterval(this.simulationInterval);
      this._isRunning.next(false);
    }
  }
  
  doTimeStep(): void {
    // Increment game time
    let totalTime = 0;
    this.cityStateService.totalTime.subscribe(time => totalTime = time);
    this.cityStateService.setTotalTime(totalTime + 1);
    
    // Initialize daily accumulators
    this.initDaily();
    
    // Initialize monthly accumulators
    if (totalTime % this.NUMOF_DAYS_IN_MONTH === 0) {
      this.initMonthly();
    }
    
    // Initialize yearly accumulators
    if (totalTime % this.NUMOF_DAYS_IN_YEAR === 0) {
      this.initYearly();
    }
    
    // Execute pending construction requests
    this.constructionManager.executePendingRequests();
    
    // Simulate all constructions
    this.simulateMappoints();
    
    // Handle periodic events
    this.doPeriodicEvents(totalTime);
  }
  
  private initDaily(): void {
    // Initialize daily accumulators
    // Reset daily statistics
    this.cityStateService.setPowerMade(0);
    this.cityStateService.setPowerUsed(0);
  }
  
  private initMonthly(): void {
    // Initialize monthly accumulators
    // This would be called at the start of each month
    this.cityStateService.updateMonthly();
  }
  
  private initYearly(): void {
    // Initialize yearly accumulators
    // This would be called at the start of each year
    this.cityStateService.updateYearly();
  }
  
  private simulateMappoints(): void {
    // Simulate all constructions
    // This would iterate through all constructions and call their update methods
    // In a real implementation, we would iterate through all tiles in the world
    // and update any constructions on those tiles
    
    // Example pseudocode:
    // for (let y = 0; y < this.world.getLength(); y++) {
    //   for (let x = 0; x < this.world.getLength(); x++) {
    //     const tile = this.world.getTile(x, y);
    //     if (tile && tile.construction) {
    //       tile.construction.update();
    //     }
    //   }
    // }
  }
  
  private doPeriodicEvents(totalTime: number): void {
    // Handle events that occur periodically
    
    // Add daily values to monthly accumulators
    this.addDailyToMonthly();
    
    // Handle start of year events
    if (totalTime % this.NUMOF_DAYS_IN_YEAR === 0) {
      this.startOfYearUpdate();
    }
    
    // Handle end of month events
    if (totalTime % this.NUMOF_DAYS_IN_MONTH === this.NUMOF_DAYS_IN_MONTH - 1) {
      this.endOfMonthUpdate();
    }
    
    // Handle end of year events
    if (totalTime % this.NUMOF_DAYS_IN_YEAR === this.NUMOF_DAYS_IN_YEAR - 1) {
      this.endOfYearUpdate();
    }
  }
  
  private addDailyToMonthly(): void {
    // Add daily values to monthly accumulators
    // This would update monthly statistics based on daily values
    // For example, adding daily power production to monthly totals
  }
  
  private startOfYearUpdate(): void {
    // Handle start of year events
    // This would be called at the start of each year
    // For example, resetting yearly statistics
  }
  
  private endOfMonthUpdate(): void {
    // Handle end of month events
    // This would be called at the end of each month
    // For example, calculating monthly taxes
  }
  
  private endOfYearUpdate(): void {
    // Handle end of year events
    // This would be called at the end of each year
    // For example, calculating yearly statistics
  }
  
  doAnimate(): void {
    // Update animations for constructions
    // This would iterate through all constructions and call their animate methods
    
    // Example pseudocode:
    // for (let y = 0; y < this.world.getLength(); y++) {
    //   for (let x = 0; x < this.world.getLength(); x++) {
    //     const tile = this.world.getTile(x, y);
    //     if (tile && tile.construction) {
    //       tile.construction.animate();
    //     }
    //   }
    // }
  }
}
