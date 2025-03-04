import { Injectable } from '@angular/core';
import { MapPoint } from '../interfaces/map-point.interface';

@Injectable({
  providedIn: 'root'
})
export class RenderingService {
  tileWidth = 64;
  tileHeight = 32;
  private zoom = 1.0;

  constructor() { }

  setZoom(zoom: number): void {
    this.zoom = zoom;
  }

  getZoom(): number {
    return this.zoom;
  }

  clearCanvas(ctx: CanvasRenderingContext2D, width: number, height: number): void {
    ctx.clearRect(0, 0, width, height);
  }

  mapToScreen(mapPoint: MapPoint): MapPoint {
    // Convert map coordinates to screen coordinates using isometric projection
    const screenX = (mapPoint.x - mapPoint.y) * (this.tileWidth / 2) * this.zoom;
    const screenY = (mapPoint.x + mapPoint.y) * (this.tileHeight / 2) * this.zoom;
    
    return { x: screenX, y: screenY };
  }

  screenToMap(screenX: number, screenY: number): MapPoint {
    // Convert screen coordinates to map coordinates using isometric projection
    const mapX = Math.floor((screenX / this.zoom / (this.tileWidth / 2) + screenY / this.zoom / (this.tileHeight / 2)) / 2);
    const mapY = Math.floor((screenY / this.zoom / (this.tileHeight / 2) - screenX / this.zoom / (this.tileWidth / 2)) / 2);
    
    return { x: mapX, y: mapY };
  }

  drawTile(ctx: CanvasRenderingContext2D, mapPoint: MapPoint, texture: HTMLImageElement | null): void {
    const screenPos = this.mapToScreen(mapPoint);
    
    // If no texture is provided, draw a simple diamond shape
    if (!texture) {
      const tileWidth = this.tileWidth * this.zoom;
      const tileHeight = this.tileHeight * this.zoom;
      
      // Draw a diamond shape
      ctx.beginPath();
      ctx.moveTo(screenPos.x, screenPos.y - tileHeight / 2);
      ctx.lineTo(screenPos.x + tileWidth / 2, screenPos.y);
      ctx.lineTo(screenPos.x, screenPos.y + tileHeight / 2);
      ctx.lineTo(screenPos.x - tileWidth / 2, screenPos.y);
      ctx.closePath();
      
      // Fill with a color based on coordinates (for debugging)
      const r = (mapPoint.x * 10) % 255;
      const g = (mapPoint.y * 10) % 255;
      const b = ((mapPoint.x + mapPoint.y) * 5) % 255;
      ctx.fillStyle = `rgb(${r}, ${g}, ${b})`;
      ctx.fill();
      
      // Draw outline
      ctx.strokeStyle = '#000';
      ctx.lineWidth = 1;
      ctx.stroke();
    } else {
      // Draw the texture
      ctx.drawImage(
        texture,
        screenPos.x - (this.tileWidth * this.zoom) / 2,
        screenPos.y - (this.tileHeight * this.zoom) / 2,
        this.tileWidth * this.zoom,
        this.tileHeight * this.zoom
      );
    }
  }
}
