import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  template: `<h1>Hello {{name}}</h1>
  <events-list></events-list>`,
})
export class AppComponent  { name = 'Angular ' + new Date().toLocaleTimeString(); }
