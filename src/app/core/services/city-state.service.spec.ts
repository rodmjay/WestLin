import { TestBed } from '@angular/core/testing';
import { CityStateService } from './city-state.service';
import { CityState as CoreCityState } from '../../../core/services/city-state';

describe('CityStateService', () => {
  let service: CityStateService;
  
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        CityStateService
      ]
    });
    
    service = TestBed.inject(CityStateService);
    
    // Mock the core city state
    (service as any).coreCityState = {
      totalTime: 0,
      money: 10000,
      population: 0,
      techLevel: 0,
      powerMade: 0,
      powerUsed: 0,
      setTotalTime: jasmine.createSpy('setTotalTime'),
      setMoney: jasmine.createSpy('setMoney'),
      setPopulation: jasmine.createSpy('setPopulation'),
      setTechLevel: jasmine.createSpy('setTechLevel'),
      setPowerMade: jasmine.createSpy('setPowerMade'),
      setPowerUsed: jasmine.createSpy('setPowerUsed'),
      updateMonthly: jasmine.createSpy('updateMonthly'),
      updateYearly: jasmine.createSpy('updateYearly'),
      onStateChanged: jasmine.createSpy('onStateChanged').and.returnValue({ unsubscribe: () => {} })
    };
  });
  
  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  
  it('should get and set totalTime', () => {
    const newValue = 100;
    service.setTotalTime(newValue);
    
    let value = 0;
    service.totalTime.subscribe(v => value = v);
    expect(value).toBe(newValue);
    expect((service as any).coreCityState.setTotalTime).toHaveBeenCalledWith(newValue);
  });
  
  it('should get and set totalMoney', () => {
    const newValue = 5000;
    service.setTotalMoney(newValue);
    
    let value = 0;
    service.totalMoney.subscribe((v: number) => value = v);
    expect(value).toBe(newValue);
    expect((service as any).coreCityState.setMoney).toHaveBeenCalledWith(newValue);
  });
  
  it('should get and set population', () => {
    const newValue = 1000;
    service.setPopulation(newValue);
    
    let value = 0;
    service.population.subscribe(v => value = v);
    expect(value).toBe(newValue);
    expect((service as any).coreCityState.setPopulation).toHaveBeenCalledWith(newValue);
  });
  
  it('should get and set techLevel', () => {
    const newValue = 5;
    service.setTechLevel(newValue);
    
    let value = 0;
    service.techLevel.subscribe(v => value = v);
    expect(value).toBe(newValue);
    expect((service as any).coreCityState.setTechLevel).toHaveBeenCalledWith(newValue);
  });
  
  it('should get and set powerMade', () => {
    const newValue = 500;
    service.setPowerMade(newValue);
    
    let value = 0;
    service.powerMade.subscribe(v => value = v);
    expect(value).toBe(newValue);
    expect((service as any).coreCityState.setPowerMade).toHaveBeenCalledWith(newValue);
  });
  
  it('should get and set powerUsed', () => {
    const newValue = 300;
    service.setPowerUsed(newValue);
    
    let value = 0;
    service.powerUsed.subscribe(v => value = v);
    expect(value).toBe(newValue);
    expect((service as any).coreCityState.setPowerUsed).toHaveBeenCalledWith(newValue);
  });
  
  it('should initialize game state', () => {
    service.initializeGameState();
    
    // Verify that the core city state methods were called
    expect((service as any).coreCityState.setTotalTime).toHaveBeenCalledWith(0);
    expect((service as any).coreCityState.setMoney).toHaveBeenCalledWith(10000);
    expect((service as any).coreCityState.setPopulation).toHaveBeenCalledWith(0);
    expect((service as any).coreCityState.setTechLevel).toHaveBeenCalledWith(0);
    expect((service as any).coreCityState.setPowerMade).toHaveBeenCalledWith(0);
    expect((service as any).coreCityState.setPowerUsed).toHaveBeenCalledWith(0);
  });
  
  it('should update monthly statistics', () => {
    service.updateMonthly();
    expect((service as any).coreCityState.updateMonthly).toHaveBeenCalled();
  });
  
  it('should update yearly statistics', () => {
    service.updateYearly();
    expect((service as any).coreCityState.updateYearly).toHaveBeenCalled();
  });
});
