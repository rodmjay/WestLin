import { CityState } from './city-state';

describe('CityState', () => {
  let cityState: CityState;
  
  beforeEach(() => {
    cityState = new CityState(10000);
  });
  
  it('should create an instance', () => {
    expect(cityState).toBeTruthy();
  });
  
  it('should initialize with default values', () => {
    expect(cityState.totalTime).toBe(0);
    expect(cityState.money).toBe(10000);
    expect(cityState.population).toBe(0);
    expect(cityState.techLevel).toBe(0);
    expect(cityState.powerMade).toBe(0);
    expect(cityState.powerUsed).toBe(0);
  });
  
  it('should set and get totalTime', () => {
    const newValue = 100;
    cityState.setTotalTime(newValue);
    expect(cityState.totalTime).toBe(newValue);
  });
  
  it('should set and get money', () => {
    const newValue = 5000;
    cityState.setMoney(newValue);
    expect(cityState.money).toBe(newValue);
  });
  
  it('should set and get population', () => {
    const newValue = 1000;
    cityState.setPopulation(newValue);
    expect(cityState.population).toBe(newValue);
  });
  
  it('should set and get techLevel', () => {
    const newValue = 5;
    cityState.setTechLevel(newValue);
    expect(cityState.techLevel).toBe(newValue);
  });
  
  it('should set and get powerMade', () => {
    const newValue = 500;
    cityState.setPowerMade(newValue);
    expect(cityState.powerMade).toBe(newValue);
  });
  
  it('should set and get powerUsed', () => {
    const newValue = 300;
    cityState.setPowerUsed(newValue);
    expect(cityState.powerUsed).toBe(newValue);
  });
  
  it('should spend money correctly', () => {
    const initialMoney = cityState.money;
    const amountToSpend = 1000;
    
    const result = cityState.spendMoney(amountToSpend);
    
    expect(result).toBe(true);
    expect(cityState.money).toBe(initialMoney - amountToSpend);
  });
  
  it('should not spend money if not enough available', () => {
    const initialMoney = cityState.money;
    const amountToSpend = initialMoney + 1000;
    
    const result = cityState.spendMoney(amountToSpend);
    
    expect(result).toBe(false);
    expect(cityState.money).toBe(initialMoney);
  });
  
  it('should earn money correctly', () => {
    const initialMoney = cityState.money;
    const amountToEarn = 1000;
    
    cityState.earnMoney(amountToEarn);
    
    expect(cityState.money).toBe(initialMoney + amountToEarn);
  });
  
  it('should update monthly statistics', () => {
    cityState.setMoney(5000);
    cityState.setPopulation(1000);
    cityState.setTechLevel(5);
    cityState.setPowerMade(500);
    cityState.setPowerUsed(300);
    
    cityState.updateMonthly();
    
    // We can't directly access private properties, but we can verify that the method runs without errors
    expect(cityState.money).toBe(5000);
  });
  
  it('should update yearly statistics', () => {
    cityState.setMoney(5000);
    cityState.setPopulation(1000);
    cityState.setTechLevel(5);
    cityState.setPowerMade(500);
    cityState.setPowerUsed(300);
    
    cityState.updateYearly();
    
    // We can't directly access private properties, but we can verify that the method runs without errors
    expect(cityState.money).toBe(5000);
  });
  
  it('should emit state changed events', () => {
    let eventFired = false;
    
    cityState.onStateChanged(() => {
      eventFired = true;
    });
    
    cityState.setMoney(5000);
    
    expect(eventFired).toBe(true);
  });
  
  it('should allow unsubscribing from state changed events', () => {
    let eventCount = 0;
    
    const subscription = cityState.onStateChanged(() => {
      eventCount++;
    });
    
    cityState.setMoney(5000);
    expect(eventCount).toBe(1);
    
    subscription.unsubscribe();
    
    cityState.setMoney(6000);
    expect(eventCount).toBe(1); // Should still be 1 since we unsubscribed
  });
});
