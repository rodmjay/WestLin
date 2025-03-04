import { Component, ElementRef, OnInit, ViewChild, AfterViewInit, HostListener } from '@angular/core';
import { RenderingService } from '../services/rendering.service';
import { World } from '../../core/models/world.model';

@Component({
  selector: 'app-game-view',
  templateUrl: './game-view.component.html',
  styleUrls: ['./game-view.component.scss']
})
export class GameViewComponent implements OnInit, AfterViewInit {
  @ViewChild('gameCanvas', { static: true }) gameCanvas!: ElementRef<HTMLCanvasElement>;
  private ctx!: CanvasRenderingContext2D;
  private viewport: { x: number, y: number } = { x: 0, y: 0 };
  private isDragging = false;
  private lastMousePos: { x: number, y: number } = { x: 0, y: 0 };
  private zoom = 1.0;

  constructor(
    private renderingService: RenderingService,
    private world: World
  ) { }

  ngOnInit(): void {
    // Initialize the component
  }

  ngAfterViewInit(): void {
    this.ctx = this.gameCanvas.nativeElement.getContext('2d')!;
    this.resizeCanvas();
    this.renderWorld();
  }

  @HostListener('window:resize')
  onResize(): void {
    this.resizeCanvas();
    this.renderWorld();
  }

  @HostListener('mousedown', ['$event'])
  onMouseDown(event: MouseEvent): void {
    this.isDragging = true;
    this.lastMousePos = { x: event.clientX, y: event.clientY };
  }

  @HostListener('mouseup')
  onMouseUp(): void {
    this.isDragging = false;
  }

  @HostListener('mousemove', ['$event'])
  onMouseMove(event: MouseEvent): void {
    if (this.isDragging) {
      const deltaX = event.clientX - this.lastMousePos.x;
      const deltaY = event.clientY - this.lastMousePos.y;
      
      this.viewport.x -= deltaX;
      this.viewport.y -= deltaY;
      
      this.lastMousePos = { x: event.clientX, y: event.clientY };
      this.renderWorld();
    }
  }

  @HostListener('wheel', ['$event'])
  onMouseWheel(event: WheelEvent): void {
    event.preventDefault();
    
    // Adjust zoom based on wheel direction
    const zoomFactor = event.deltaY > 0 ? 0.9 : 1.1;
    this.zoom *= zoomFactor;
    
    // Constrain zoom
    this.zoom = Math.max(0.5, Math.min(2.0, this.zoom));
    
    this.renderingService.setZoom(this.zoom);
    this.renderWorld();
  }

  private resizeCanvas(): void {
    const canvas = this.gameCanvas.nativeElement;
    canvas.width = canvas.clientWidth;
    canvas.height = canvas.clientHeight;
  }

  private renderWorld(): void {
    const canvas = this.gameCanvas.nativeElement;
    this.renderingService.clearCanvas(this.ctx, canvas.width, canvas.height);
    
    // Calculate visible tiles
    const viewportCenter = this.renderingService.screenToMap(
      canvas.width / 2 - this.viewport.x,
      canvas.height / 2 - this.viewport.y
    );
    
    // Determine the range of tiles to render
    const tilesX = Math.ceil(canvas.width / (this.renderingService.tileWidth * this.zoom)) + 2;
    const tilesY = Math.ceil(canvas.height / (this.renderingService.tileHeight * this.zoom)) + 2;
    
    // Render visible tiles
    for (let y = viewportCenter.y - tilesY; y <= viewportCenter.y + tilesY; y++) {
      for (let x = viewportCenter.x - tilesX; x <= viewportCenter.x + tilesX; x++) {
        if (this.world.isInside(x, y)) {
          const tile = this.world.getTile(x, y);
          if (tile) {
            // Adjust for viewport position
            const screenPos = this.renderingService.mapToScreen({ x, y });
            screenPos.x += canvas.width / 2 - this.viewport.x;
            screenPos.y += canvas.height / 2 - this.viewport.y;
            
            // Only render if the tile is visible
            if (
              screenPos.x > -this.renderingService.tileWidth * this.zoom &&
              screenPos.x < canvas.width + this.renderingService.tileWidth * this.zoom &&
              screenPos.y > -this.renderingService.tileHeight * this.zoom &&
              screenPos.y < canvas.height + this.renderingService.tileHeight * this.zoom
            ) {
              // Draw the tile
              this.renderingService.drawTile(this.ctx, { x, y }, null);
              
              // Draw construction if present
              if (tile.construction) {
                // TODO: Draw construction texture
              }
            }
          }
        }
      }
    }
  }
}
