import { Component } from '@angular/core';
import { GameViewComponent } from './ui/game-view/game-view.component';
import { MiniMapComponent } from './ui/mini-map/mini-map.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  standalone: true,
  imports: [GameViewComponent, MiniMapComponent]
})
export class AppComponent {
  title = 'lincity-ng-web';
}
