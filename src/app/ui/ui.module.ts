import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameViewComponent } from './game-view/game-view.component';
import { MiniMapComponent } from './mini-map/mini-map.component';
import { RenderingService } from './services/rendering.service';
import { TextureLoaderService } from './services/texture-loader.service';

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    GameViewComponent,
    MiniMapComponent
  ],
  exports: [
    GameViewComponent,
    MiniMapComponent
  ],
  providers: [
    RenderingService,
    TextureLoaderService
  ]
})
export class UiModule { }
