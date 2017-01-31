import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  template: `
    <nav-bar></nav-bar>
	<events-list></events-list>
	`,
})
export class AppComponent  { name = 'Angular ' + new Date().toLocaleTimeString(); }
