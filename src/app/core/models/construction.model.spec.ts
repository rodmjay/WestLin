import { TestBed } from '@angular/core/testing';
import { ConstructionBase } from './construction.model';
import { Commodity } from '../enums/commodity.enum';

describe('ConstructionBase', () => {
  let construction: ConstructionBase;
  
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ConstructionBase]
    });
    
    construction = TestBed.inject(ConstructionBase);
  });
  
  it('should create an instance', () => {
    expect(construction).toBeTruthy();
  });
  
  it('should initialize commodities to zero', () => {
    for (let i = Commodity.STUFF_INIT; i < Commodity.STUFF_COUNT; i++) {
      expect(construction.commodityCount[i]).toBe(0);
      expect(construction.commodityProd[i]).toBe(0);
      expect(construction.commodityProdPrev[i]).toBe(0);
      expect(construction.commodityMaxProd[i]).toBe(0);
      expect(construction.commodityMaxCons[i]).toBe(0);
    }
  });
  
  it('should produce stuff correctly', () => {
    const amount = 10;
    const produced = construction.produceStuff(Commodity.STUFF_FOOD, amount);
    
    expect(produced).toBe(amount);
    expect(construction.commodityCount[Commodity.STUFF_FOOD]).toBe(amount);
    expect(construction.commodityProd[Commodity.STUFF_FOOD]).toBe(amount);
  });
  
  it('should consume stuff correctly', () => {
    const initialAmount = 10;
    construction.produceStuff(Commodity.STUFF_FOOD, initialAmount);
    
    const consumeAmount = 5;
    const consumed = construction.consumeStuff(Commodity.STUFF_FOOD, consumeAmount);
    
    expect(consumed).toBe(consumeAmount);
    expect(construction.commodityCount[Commodity.STUFF_FOOD]).toBe(initialAmount - consumeAmount);
    expect(construction.commodityProd[Commodity.STUFF_FOOD]).toBe(initialAmount - consumeAmount);
  });
  
  it('should not consume more than available', () => {
    const initialAmount = 10;
    construction.produceStuff(Commodity.STUFF_FOOD, initialAmount);
    
    const consumeAmount = 15;
    const consumed = construction.consumeStuff(Commodity.STUFF_FOOD, consumeAmount);
    
    expect(consumed).toBe(initialAmount);
    expect(construction.commodityCount[Commodity.STUFF_FOOD]).toBe(0);
    expect(construction.commodityProd[Commodity.STUFF_FOOD]).toBe(0);
  });
  
  it('should level stuff correctly', () => {
    const initialAmount = 10;
    construction.produceStuff(Commodity.STUFF_FOOD, initialAmount);
    
    const newLevel = 15;
    const diff = construction.levelStuff(Commodity.STUFF_FOOD, newLevel);
    
    expect(diff).toBe(newLevel - initialAmount);
    expect(construction.commodityCount[Commodity.STUFF_FOOD]).toBe(newLevel);
    expect(construction.commodityProd[Commodity.STUFF_FOOD]).toBe(initialAmount + (newLevel - initialAmount));
  });
});
