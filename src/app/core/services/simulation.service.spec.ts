import { TestBed } from '@angular/core/testing';
import { SimulationService } from './simulation.service';
import { CityStateService } from './city-state.service';
import { World } from '@core/models/world';
import { ConstructionManagerService } from './construction-manager.service';
import { Simulation as CoreSimulation } from '@core/services/simulation';

describe('SimulationService', () => {
  let service: SimulationService;
  let cityStateService: CityStateService;
  let world: World;
  let constructionManager: ConstructionManagerService;
  
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        SimulationService,
        CityStateService,
        ConstructionManagerService,
        {
          provide: World,
          useFactory: () => new World(100)
        }
      ]
    });
    
    service = TestBed.inject(SimulationService);
    cityStateService = TestBed.inject(CityStateService);
    world = TestBed.inject(World);
    constructionManager = TestBed.inject(ConstructionManagerService);
    
    // Mock the core simulation
    (service as any).coreSimulation = {
      start: jasmine.createSpy('start'),
      stop: jasmine.createSpy('stop'),
      setSpeed: jasmine.createSpy('setSpeed'),
      onRunningChanged: jasmine.createSpy('onRunningChanged').and.returnValue({ unsubscribe: () => {} }),
      onSpeedChanged: jasmine.createSpy('onSpeedChanged').and.returnValue({ unsubscribe: () => {} })
    };
  });
  
  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  
  it('should start and stop simulation', () => {
    expect(service['_isRunning'].value).toBeFalse();
    
    service.start();
    expect(service['_isRunning'].value).toBeTrue();
    
    service.stop();
    expect(service['_isRunning'].value).toBeFalse();
  });
  
  it('should set simulation speed', () => {
    const newSpeed = 2;
    service.setSpeed(newSpeed);
    
    let speed = 0;
    service.speed.subscribe(s => speed = s);
    expect(speed).toBe(newSpeed);
  });
  
  it('should restart simulation when speed changes while running', () => {
    spyOn(service, 'stop');
    spyOn(service, 'start');
    
    service['_isRunning'].next(true);
    service.setSpeed(2);
    
    expect(service.stop).toHaveBeenCalled();
    expect(service.start).toHaveBeenCalled();
  });
});
