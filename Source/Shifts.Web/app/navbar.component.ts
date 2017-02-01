import { Component } from '@angular/core';

@Component({
	selector: 'nav-bar',
	templateUrl: "app/navbar.component.html",
	styles: [`
		.nav.navbar-nav {font-size: 15px;}
		#searchForm  {margin-right: 100px;}
		li > a.active { color: #F97924;}
	`]
})
export class NavBarComponent {
}