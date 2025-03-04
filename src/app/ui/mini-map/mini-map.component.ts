import { Component, ElementRef, OnInit, ViewChild, AfterViewInit, Output, EventEmitter } from '@angular/core';
import { World } from '../../core/models/world.model';
import { MapPoint } from '../interfaces/map-point.interface';

@Component({
  selector: 'app-mini-map',
  templateUrl: './mini-map.component.html',
  styleUrls: ['./mini-map.component.scss'],
  standalone: true
})
export class MiniMapComponent implements OnInit, AfterViewInit {
  @ViewChild('miniMapCanvas', { static: true }) miniMapCanvas!: ElementRef<HTMLCanvasElement>;
  @Output() centerChanged = new EventEmitter<MapPoint>();
  
  private ctx!: CanvasRenderingContext2D;
  private tileSize = 2; // Size of each tile in the minimap
  private viewportRect: { x: number, y: number, width: number, height: number } = { x: 0, y: 0, width: 0, height: 0 };
  
  constructor(private world: World) { }

  ngOnInit(): void {
    // Initialize the component
  }

  ngAfterViewInit(): void {
    this.ctx = this.miniMapCanvas.nativeElement.getContext('2d')!;
    this.renderMiniMap();
  }

  onMiniMapClick(event: MouseEvent): void {
    const canvas = this.miniMapCanvas.nativeElement;
    const rect = canvas.getBoundingClientRect();
    const x = Math.floor((event.clientX - rect.left) / this.tileSize);
    const y = Math.floor((event.clientY - rect.top) / this.tileSize);
    
    if (this.world.isInside(x, y)) {
      this.centerChanged.emit({ x, y });
    }
  }

  updateViewport(center: MapPoint, visibleTilesX: number, visibleTilesY: number): void {
    this.viewportRect = {
      x: center.x - visibleTilesX / 2,
      y: center.y - visibleTilesY / 2,
      width: visibleTilesX,
      height: visibleTilesY
    };
    this.renderMiniMap();
  }

  private renderMiniMap(): void {
    const canvas = this.miniMapCanvas.nativeElement;
    const worldSize = this.world.getLength();
    
    // Set canvas size based on world size
    canvas.width = worldSize * this.tileSize;
    canvas.height = worldSize * this.tileSize;
    
    // Clear canvas
    this.ctx.clearRect(0, 0, canvas.width, canvas.height);
    
    // Draw all tiles
    for (let y = 0; y < worldSize; y++) {
      for (let x = 0; x < worldSize; x++) {
        if (this.world.isInside(x, y)) {
          const tile = this.world.getTile(x, y);
          if (tile) {
            // Set color based on tile type
            let color = '#8B8B8B'; // Default color
            
            if (tile.construction) {
              // Set color based on construction type
              color = '#FF0000'; // Example color for construction
            } else if (tile.type === 1) { // Assuming 1 is water
              color = '#0000FF';
            } else if (tile.type === 2) { // Assuming 2 is grass
              color = '#00FF00';
            }
            
            this.ctx.fillStyle = color;
            this.ctx.fillRect(x * this.tileSize, y * this.tileSize, this.tileSize, this.tileSize);
          }
        }
      }
    }
    
    // Draw viewport rectangle
    this.ctx.strokeStyle = '#FFFFFF';
    this.ctx.lineWidth = 2;
    this.ctx.strokeRect(
      this.viewportRect.x * this.tileSize,
      this.viewportRect.y * this.tileSize,
      this.viewportRect.width * this.tileSize,
      this.viewportRect.height * this.tileSize
    );
  }
}
