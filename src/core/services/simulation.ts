import { EventEmitter } from '../utils/event-emitter';
import { CityState } from './city-state';
import { World } from '../models/world';
import { ConstructionManager } from './construction-manager';

export class Simulation {
  // Events
  private runningChanged = new EventEmitter<boolean>();
  private speedChanged = new EventEmitter<number>();
  
  // Simulation properties
  private _isRunning: boolean = false;
  private _speed: number = 1;
  private simulationInterval: number | null = null;
  private readonly NUMOF_DAYS_IN_MONTH = 100;
  private readonly NUMOF_DAYS_IN_YEAR = 1200; // 12 * NUMOF_DAYS_IN_MONTH
  
  constructor(
    private cityState: CityState,
    private world: World,
    private constructionManager: ConstructionManager
  ) {}
  
  // Getters
  get isRunning(): boolean { return this._isRunning; }
  get speed(): number { return this._speed; }
  
  // Event subscriptions
  onRunningChanged(callback: (isRunning: boolean) => void): { unsubscribe: () => void } {
    return this.runningChanged.subscribe(callback);
  }
  
  onSpeedChanged(callback: (speed: number) => void): { unsubscribe: () => void } {
    return this.speedChanged.subscribe(callback);
  }
  
  setSpeed(value: number): void {
    this._speed = value;
    this.speedChanged.emit(value);
    if (this._isRunning) {
      this.stop();
      this.start();
    }
  }
  
  start(): void {
    if (!this._isRunning) {
      const interval = 1000 / this._speed;
      this.simulationInterval = window.setInterval(() => {
        this.doTimeStep();
      }, interval);
      this._isRunning = true;
      this.runningChanged.emit(true);
    }
  }
  
  stop(): void {
    if (this._isRunning && this.simulationInterval !== null) {
      window.clearInterval(this.simulationInterval);
      this.simulationInterval = null;
      this._isRunning = false;
      this.runningChanged.emit(false);
    }
  }
  
  doTimeStep(): void {
    // Increment game time
    this.cityState.setTotalTime(this.cityState.totalTime + 1);
    
    // Initialize daily accumulators
    this.initDaily();
    
    // Initialize monthly accumulators
    if (this.cityState.totalTime % this.NUMOF_DAYS_IN_MONTH === 0) {
      this.initMonthly();
    }
    
    // Initialize yearly accumulators
    if (this.cityState.totalTime % this.NUMOF_DAYS_IN_YEAR === 0) {
      this.initYearly();
    }
    
    // Execute pending construction requests
    this.constructionManager.executePendingRequests();
    
    // Simulate all constructions
    this.simulateMappoints();
    
    // Handle periodic events
    this.doPeriodicEvents(this.cityState.totalTime);
  }
  
  private initDaily(): void {
    // Initialize daily accumulators
    // Reset daily statistics
    this.cityState.setPowerMade(0);
    this.cityState.setPowerUsed(0);
  }
  
  private initMonthly(): void {
    // Initialize monthly accumulators
    // This would be called at the start of each month
    this.cityState.updateMonthly();
  }
  
  private initYearly(): void {
    // Initialize yearly accumulators
    // This would be called at the start of each year
    this.cityState.updateYearly();
  }
  
  private simulateMappoints(): void {
    // Simulate all constructions
    // This would iterate through all constructions and call their update methods
    // In a real implementation, we would iterate through all tiles in the world
    // and update any constructions on those tiles
    
    // Example implementation:
    for (let y = 0; y < this.world.getLength(); y++) {
      for (let x = 0; x < this.world.getLength(); x++) {
        const tile = this.world.getTile(x, y);
        if (tile && tile.construction) {
          tile.construction.update();
        }
      }
    }
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
    
    // Example implementation:
    for (let y = 0; y < this.world.getLength(); y++) {
      for (let x = 0; x < this.world.getLength(); x++) {
        const tile = this.world.getTile(x, y);
        if (tile && tile.construction) {
          tile.construction.animate();
        }
      }
    }
  }
}
