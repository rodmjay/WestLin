import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { provideAnimations } from '@angular/platform-browser/animations';
import { importProvidersFrom } from '@angular/core';
import { CoreModule } from './app/core/core.module';
import { UiModule } from './app/ui/ui.module';

bootstrapApplication(AppComponent, {
  providers: [
    provideAnimations(),
    importProvidersFrom(CoreModule, UiModule)
  ]
}).catch(err => console.error(err));
