import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TextureLoaderService {
  private textureCache: Map<string, HTMLImageElement> = new Map();
  private _loadingProgress = new BehaviorSubject<number>(0);
  private totalTextures = 0;
  private loadedTextures = 0;

  constructor() { }

  get loadingProgress(): Observable<number> {
    return this._loadingProgress.asObservable();
  }

  preloadTextures(textureUrls: string[]): Promise<void> {
    this.totalTextures = textureUrls.length;
    this.loadedTextures = 0;
    this._loadingProgress.next(0);

    const promises = textureUrls.map(url => this.loadTexture(url));
    return Promise.all(promises).then(() => {
      this._loadingProgress.next(100);
    });
  }

  getTexture(url: string): HTMLImageElement | null {
    return this.textureCache.get(url) || null;
  }

  private loadTexture(url: string): Promise<void> {
    return new Promise<void>((resolve, reject) => {
      if (this.textureCache.has(url)) {
        this.updateProgress();
        resolve();
        return;
      }

      const img = new Image();
      img.onload = () => {
        this.textureCache.set(url, img);
        this.updateProgress();
        resolve();
      };
      img.onerror = () => {
        console.error(`Failed to load texture: ${url}`);
        this.updateProgress();
        resolve(); // Resolve anyway to continue loading other textures
      };
      img.src = url;
    });
  }

  private updateProgress(): void {
    this.loadedTextures++;
    const progress = Math.floor((this.loadedTextures / this.totalTextures) * 100);
    this._loadingProgress.next(progress);
  }
}
