import { Component, OnInit } from '@angular/core'
import { EventService  } from './event.service'

@Component({
  templateUrl:'/app/event-details.component.html',
  styles:[`
	.container { padding-left:20px; padding-right: 20px;}
	.event-image: {height: 100px;}
  `]
})
export class EventDetailsComponent implements  OnInit {
	
	constructor(private eventService: EventService) {
		
	}

	ngOnInit() {
		this.event = this.eventService.getEvent(1);
	}

	event : any;
}