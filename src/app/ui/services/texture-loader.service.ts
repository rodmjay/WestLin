import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TextureLoaderService {
  private textures: Map<string, HTMLImageElement> = new Map();
  
  constructor() {}
  
  loadTexture(key: string, url: string): Promise<HTMLImageElement> {
    return new Promise((resolve, reject) => {
      if (this.textures.has(key)) {
        resolve(this.textures.get(key)!);
        return;
      }
      
      const img = new Image();
      img.onload = () => {
        this.textures.set(key, img);
        resolve(img);
      };
      img.onerror = () => {
        reject(new Error(`Failed to load texture: ${url}`));
      };
      img.src = url;
    });
  }
  
  getTexture(key: string): HTMLImageElement | null {
    return this.textures.get(key) || null;
  }
}
