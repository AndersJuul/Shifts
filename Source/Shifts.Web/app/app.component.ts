import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  template: `
    <nav-bar></nav-bar>
    <div class="row">
	    <router-outlet></router-outlet>
    </div>
	`,
})
export class AppComponent  { name = 'Angular ' + new Date().toLocaleTimeString(); }
