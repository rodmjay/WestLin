import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SimpleTestComponent } from './simple-test.component';

@NgModule({
  declarations: [SimpleTestComponent],
  imports: [CommonModule],
  exports: [SimpleTestComponent]
})
export class SimpleTestModule {}
