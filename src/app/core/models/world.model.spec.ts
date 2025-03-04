import { TestBed } from '@angular/core/testing';
import { World } from './world.model';

describe('World', () => {
  let world: World;
  
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [World]
    });
    
    world = TestBed.inject(World);
  });
  
  it('should create an instance', () => {
    expect(world).toBeTruthy();
  });
  
  it('should initialize with the correct size', () => {
    expect(world.getLength()).toBe(100);
  });
  
  it('should check if coordinates are inside the world', () => {
    expect(world.isInside(50, 50)).toBe(true);
    expect(world.isInside(-1, 50)).toBe(false);
    expect(world.isInside(50, -1)).toBe(false);
    expect(world.isInside(100, 50)).toBe(false);
    expect(world.isInside(50, 100)).toBe(false);
  });
  
  it('should check if coordinates are on the border', () => {
    expect(world.isBorder(0, 50)).toBe(true);
    expect(world.isBorder(99, 50)).toBe(true);
    expect(world.isBorder(50, 0)).toBe(true);
    expect(world.isBorder(50, 99)).toBe(true);
    expect(world.isBorder(50, 50)).toBe(false);
  });
  
  it('should get a tile at valid coordinates', () => {
    const tile = world.getTile(50, 50);
    expect(tile).toBeTruthy();
  });
  
  it('should return null for a tile at invalid coordinates', () => {
    const tile = world.getTile(-1, 50);
    expect(tile).toBeNull();
  });
});
