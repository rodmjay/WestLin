import { Injectable } from '@angular/core';
import { MapPoint } from '../interfaces/map-point.interface';

@Injectable({
  providedIn: 'root'
})
export class RenderingService {
  // Isometric tile dimensions
  tileWidth = 64;
  tileHeight = 32;
  
  // Zoom level
  private zoom = 1.0;
  
  constructor() {}
  
  setZoom(zoom: number): void {
    this.zoom = zoom;
  }
  
  // Convert map coordinates to screen coordinates
  mapToScreen(point: MapPoint): MapPoint {
    return {
      x: (point.x - point.y) * (this.tileWidth / 2) * this.zoom,
      y: (point.x + point.y) * (this.tileHeight / 2) * this.zoom
    };
  }
  
  // Convert screen coordinates to map coordinates
  screenToMap(x: number, y: number): MapPoint {
    const tileWidthHalf = (this.tileWidth / 2) * this.zoom;
    const tileHeightHalf = (this.tileHeight / 2) * this.zoom;
    
    return {
      x: Math.floor((x / tileWidthHalf + y / tileHeightHalf) / 2),
      y: Math.floor((y / tileHeightHalf - x / tileWidthHalf) / 2)
    };
  }
  
  // Clear the canvas
  clearCanvas(ctx: CanvasRenderingContext2D, width: number, height: number): void {
    ctx.clearRect(0, 0, width, height);
  }
  
  // Draw a tile at the specified map coordinates
  drawTile(ctx: CanvasRenderingContext2D, point: MapPoint, texture: HTMLImageElement | null): void {
    const screenPos = this.mapToScreen(point);
    
    if (texture) {
      // Draw the texture
      ctx.drawImage(
        texture,
        screenPos.x - (this.tileWidth / 2) * this.zoom,
        screenPos.y - (this.tileHeight / 2) * this.zoom,
        this.tileWidth * this.zoom,
        this.tileHeight * this.zoom
      );
    } else {
      // Draw a placeholder rectangle
      ctx.fillStyle = '#CCCCCC';
      ctx.strokeStyle = '#333333';
      ctx.lineWidth = 1;
      
      // Draw isometric tile
      ctx.beginPath();
      ctx.moveTo(screenPos.x, screenPos.y - (this.tileHeight / 2) * this.zoom);
      ctx.lineTo(screenPos.x + (this.tileWidth / 2) * this.zoom, screenPos.y);
      ctx.lineTo(screenPos.x, screenPos.y + (this.tileHeight / 2) * this.zoom);
      ctx.lineTo(screenPos.x - (this.tileWidth / 2) * this.zoom, screenPos.y);
      ctx.closePath();
      
      ctx.fill();
      ctx.stroke();
    }
  }
}
