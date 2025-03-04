import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { CityState as CoreCityState } from '@core/services/city-state';

@Injectable({
  providedIn: 'root'
})
export class CityStateService {
  // Core implementation
  private coreCityState: CoreCityState = new CoreCityState(10000);
  // Population statistics
  private _population = new BehaviorSubject<number>(0);
  private _starvingPopulation = new BehaviorSubject<number>(0);
  private _housedPopulation = new BehaviorSubject<number>(0);
  private _totalHousing = new BehaviorSubject<number>(0);
  private _housing = new BehaviorSubject<number>(0);
  private _unemployedPopulation = new BehaviorSubject<number>(0);
  private _peoplePool = new BehaviorSubject<number>(0);
  private _maxPopEver = new BehaviorSubject<number>(0);
  private _totalEvacuated = new BehaviorSubject<number>(0);
  private _totalBirths = new BehaviorSubject<number>(0);
  
  // Economic variables
  private _totalMoney = new BehaviorSubject<number>(0);
  private _incomeTaxRate = new BehaviorSubject<number>(0);
  private _coalTaxRate = new BehaviorSubject<number>(0);
  private _doleRate = new BehaviorSubject<number>(0);
  private _transportCostRate = new BehaviorSubject<number>(0);
  private _goodsTaxRate = new BehaviorSubject<number>(0);
  private _exportTaxRate = new BehaviorSubject<number>(0);
  private _importCostRate = new BehaviorSubject<number>(0);
  
  // Technology
  private _techLevel = new BehaviorSubject<number>(0);
  private _highestTechLevel = new BehaviorSubject<number>(0);
  
  // Game time
  private _totalTime = new BehaviorSubject<number>(0);
  
  // Resource production and consumption
  private _powerMade = new BehaviorSubject<number>(0);
  private _powerUsed = new BehaviorSubject<number>(0);
  private _coalMade = new BehaviorSubject<number>(0);
  private _coalUsed = new BehaviorSubject<number>(0);
  private _goodsMade = new BehaviorSubject<number>(0);
  private _goodsUsed = new BehaviorSubject<number>(0);
  private _oreMade = new BehaviorSubject<number>(0);
  private _oreUsed = new BehaviorSubject<number>(0);
  
  // Getters and setters for all properties
  get population(): Observable<number> {
    return this._population.asObservable();
  }
  
  setPopulation(value: number): void {
    this._population.next(value);
  }
  
  get starvingPopulation(): Observable<number> {
    return this._starvingPopulation.asObservable();
  }
  
  setStarvingPopulation(value: number): void {
    this._starvingPopulation.next(value);
  }
  
  get housedPopulation(): Observable<number> {
    return this._housedPopulation.asObservable();
  }
  
  setHousedPopulation(value: number): void {
    this._housedPopulation.next(value);
  }
  
  get totalHousing(): Observable<number> {
    return this._totalHousing.asObservable();
  }
  
  setTotalHousing(value: number): void {
    this._totalHousing.next(value);
  }
  
  get housing(): Observable<number> {
    return this._housing.asObservable();
  }
  
  setHousing(value: number): void {
    this._housing.next(value);
  }
  
  get unemployedPopulation(): Observable<number> {
    return this._unemployedPopulation.asObservable();
  }
  
  setUnemployedPopulation(value: number): void {
    this._unemployedPopulation.next(value);
  }
  
  get peoplePool(): Observable<number> {
    return this._peoplePool.asObservable();
  }
  
  setPeoplePool(value: number): void {
    this._peoplePool.next(value);
  }
  
  get maxPopEver(): Observable<number> {
    return this._maxPopEver.asObservable();
  }
  
  setMaxPopEver(value: number): void {
    this._maxPopEver.next(value);
  }
  
  get totalEvacuated(): Observable<number> {
    return this._totalEvacuated.asObservable();
  }
  
  setTotalEvacuated(value: number): void {
    this._totalEvacuated.next(value);
  }
  
  get totalBirths(): Observable<number> {
    return this._totalBirths.asObservable();
  }
  
  setTotalBirths(value: number): void {
    this._totalBirths.next(value);
  }
  
  get totalMoney(): Observable<number> {
    return this._totalMoney.asObservable();
  }
  
  setTotalMoney(value: number): void {
    this._totalMoney.next(value);
  }
  
  get incomeTaxRate(): Observable<number> {
    return this._incomeTaxRate.asObservable();
  }
  
  setIncomeTaxRate(value: number): void {
    this._incomeTaxRate.next(value);
  }
  
  get coalTaxRate(): Observable<number> {
    return this._coalTaxRate.asObservable();
  }
  
  setCoalTaxRate(value: number): void {
    this._coalTaxRate.next(value);
  }
  
  get doleRate(): Observable<number> {
    return this._doleRate.asObservable();
  }
  
  setDoleRate(value: number): void {
    this._doleRate.next(value);
  }
  
  get transportCostRate(): Observable<number> {
    return this._transportCostRate.asObservable();
  }
  
  setTransportCostRate(value: number): void {
    this._transportCostRate.next(value);
  }
  
  get goodsTaxRate(): Observable<number> {
    return this._goodsTaxRate.asObservable();
  }
  
  setGoodsTaxRate(value: number): void {
    this._goodsTaxRate.next(value);
  }
  
  get exportTaxRate(): Observable<number> {
    return this._exportTaxRate.asObservable();
  }
  
  setExportTaxRate(value: number): void {
    this._exportTaxRate.next(value);
  }
  
  get importCostRate(): Observable<number> {
    return this._importCostRate.asObservable();
  }
  
  setImportCostRate(value: number): void {
    this._importCostRate.next(value);
  }
  
  get techLevel(): Observable<number> {
    return this._techLevel.asObservable();
  }
  
  setTechLevel(value: number): void {
    this._techLevel.next(value);
  }
  
  get highestTechLevel(): Observable<number> {
    return this._highestTechLevel.asObservable();
  }
  
  setHighestTechLevel(value: number): void {
    this._highestTechLevel.next(value);
  }
  
  get totalTime(): Observable<number> {
    return this._totalTime.asObservable();
  }
  
  setTotalTime(value: number): void {
    this._totalTime.next(value);
  }
  
  get powerMade(): Observable<number> {
    return this._powerMade.asObservable();
  }
  
  setPowerMade(value: number): void {
    this._powerMade.next(value);
  }
  
  get powerUsed(): Observable<number> {
    return this._powerUsed.asObservable();
  }
  
  setPowerUsed(value: number): void {
    this._powerUsed.next(value);
  }
  
  get coalMade(): Observable<number> {
    return this._coalMade.asObservable();
  }
  
  setCoalMade(value: number): void {
    this._coalMade.next(value);
  }
  
  get coalUsed(): Observable<number> {
    return this._coalUsed.asObservable();
  }
  
  setCoalUsed(value: number): void {
    this._coalUsed.next(value);
  }
  
  get goodsMade(): Observable<number> {
    return this._goodsMade.asObservable();
  }
  
  setGoodsMade(value: number): void {
    this._goodsMade.next(value);
  }
  
  get goodsUsed(): Observable<number> {
    return this._goodsUsed.asObservable();
  }
  
  setGoodsUsed(value: number): void {
    this._goodsUsed.next(value);
  }
  
  get oreMade(): Observable<number> {
    return this._oreMade.asObservable();
  }
  
  setOreMade(value: number): void {
    this._oreMade.next(value);
  }
  
  get oreUsed(): Observable<number> {
    return this._oreUsed.asObservable();
  }
  
  setOreUsed(value: number): void {
    this._oreUsed.next(value);
  }
  
  // Game state initialization
  initializeGameState(): void {
    // Initialize the core city state
    this.coreCityState = new CoreCityState(10000);
    
    // Subscribe to core state changes
    this.coreCityState.onStateChanged(() => {
      this._totalTime.next(this.coreCityState.totalTime);
      this._totalMoney.next(this.coreCityState.money);
      this._population.next(this.coreCityState.population);
      this._techLevel.next(this.coreCityState.techLevel);
      this._powerMade.next(this.coreCityState.powerMade);
      this._powerUsed.next(this.coreCityState.powerUsed);
    });
    
    // Initialize Angular observables
    this._totalMoney.next(10000); // Starting money
    this._techLevel.next(0);
    this._highestTechLevel.next(0);
    this._totalTime.next(0);
    this._population.next(0);
    this._starvingPopulation.next(0);
    this._housedPopulation.next(0);
    this._totalHousing.next(0);
    this._housing.next(0);
    this._unemployedPopulation.next(0);
    this._peoplePool.next(0);
    this._maxPopEver.next(0);
    this._totalEvacuated.next(0);
    this._totalBirths.next(0);
    this._incomeTaxRate.next(0);
    this._coalTaxRate.next(0);
    this._doleRate.next(0);
    this._transportCostRate.next(0);
    this._goodsTaxRate.next(0);
    this._exportTaxRate.next(0);
    this._importCostRate.next(0);
    this._powerMade.next(0);
    this._powerUsed.next(0);
    this._coalMade.next(0);
    this._coalUsed.next(0);
    this._goodsMade.next(0);
    this._goodsUsed.next(0);
    this._oreMade.next(0);
    this._oreUsed.next(0);
  }
  
  // Monthly update functions
  updateMonthly(): void {
    // Delegate to core implementation
    this.coreCityState.updateMonthly();
    
    // Update monthly statistics
    // This would be called from the simulation service
    
    // Reset monthly production counters
    this._powerMade.next(0);
    this._powerUsed.next(0);
    this._coalMade.next(0);
    this._coalUsed.next(0);
    this._goodsMade.next(0);
    this._goodsUsed.next(0);
    this._oreMade.next(0);
    this._oreUsed.next(0);
  }
  
  // Yearly update functions
  updateYearly(): void {
    // Delegate to core implementation
    this.coreCityState.updateYearly();
    
    // Update yearly statistics
    // This would be called from the simulation service
    
    // Check for new population records
    let currentPop = 0;
    let maxPop = 0;
    this._population.subscribe(pop => currentPop = pop);
    this._maxPopEver.subscribe(pop => maxPop = pop);
    
    if (currentPop > maxPop) {
      this._maxPopEver.next(currentPop);
    }
  }
}
