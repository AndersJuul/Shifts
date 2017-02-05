import { Component, Input } from '@angular/core';

@Component({
	moduleId: module.id,
	selector: 'driver-thumbnail',
	templateUrl: "./driver-thumbnail.component.html",
	styles: [`
	.pad-left {margin-left: 30px;}
	.well  {color: #bbb;}
	`]
})
export class DriverThumbnailComponent {
	@Input()
	driver: any
}