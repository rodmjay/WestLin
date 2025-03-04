import { EventEmitter } from '../utils/event-emitter';

export class CityState {
  // Events
  private stateChanged = new EventEmitter<void>();
  
  // City state properties
  private _totalTime: number = 0;
  private _money: number = 0;
  private _population: number = 0;
  private _techLevel: number = 0;
  private _powerMade: number = 0;
  private _powerUsed: number = 0;
  
  // Monthly and yearly statistics
  private _monthlyStats: any = {};
  private _yearlyStats: any = {};
  
  constructor(initialMoney: number = 10000) {
    this._money = initialMoney;
  }
  
  // Getters
  get totalTime(): number { return this._totalTime; }
  get money(): number { return this._money; }
  get population(): number { return this._population; }
  get techLevel(): number { return this._techLevel; }
  get powerMade(): number { return this._powerMade; }
  get powerUsed(): number { return this._powerUsed; }
  
  // Setters with event emission
  setTotalTime(value: number): void {
    this._totalTime = value;
    this.stateChanged.emit();
  }
  
  setMoney(value: number): void {
    this._money = value;
    this.stateChanged.emit();
  }
  
  setPopulation(value: number): void {
    this._population = value;
    this.stateChanged.emit();
  }
  
  setTechLevel(value: number): void {
    this._techLevel = value;
    this.stateChanged.emit();
  }
  
  setPowerMade(value: number): void {
    this._powerMade = value;
    this.stateChanged.emit();
  }
  
  setPowerUsed(value: number): void {
    this._powerUsed = value;
    this.stateChanged.emit();
  }
  
  // Helper methods
  spendMoney(amount: number): boolean {
    if (this._money >= amount) {
      this._money -= amount;
      this.stateChanged.emit();
      return true;
    }
    return false;
  }
  
  earnMoney(amount: number): void {
    this._money += amount;
    this.stateChanged.emit();
  }
  
  // Update methods
  updateMonthly(): void {
    // Update monthly statistics
    this._monthlyStats = {
      money: this._money,
      population: this._population,
      techLevel: this._techLevel,
      powerMade: this._powerMade,
      powerUsed: this._powerUsed
    };
  }
  
  updateYearly(): void {
    // Update yearly statistics
    this._yearlyStats = {
      money: this._money,
      population: this._population,
      techLevel: this._techLevel,
      powerMade: this._powerMade,
      powerUsed: this._powerUsed
    };
  }
  
  // Event subscription
  onStateChanged(callback: () => void): { unsubscribe: () => void } {
    return this.stateChanged.subscribe(callback);
  }
}
