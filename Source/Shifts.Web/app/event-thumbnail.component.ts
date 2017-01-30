import { Component, Input } from '@angular/core';

@Component({
	moduleId: module.id,
	selector: 'event-thumbnail',    
	templateUrl: './event-thumbnail.component.html',
	styles: [`
	.pad-left {margin-left: 30px;}
	.well  {color: #bbb;}
	`]
	})
export class EventThumbnailComponent {
  @Input()  event : any
}