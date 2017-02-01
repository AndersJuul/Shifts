import { Component, OnInit } from '@angular/core'
import { EventService  } from './event.service'
import { ActivatedRoute } from '@angular/router'

@Component({
  templateUrl:'/app/create-event.component.html',
  styles:[`
	.container { padding-left:20px; padding-right: 20px;}
	.event-image: {height: 100px;}
  `]
})
export class CreateEventComponent implements  OnInit {
	
	constructor(private eventService: EventService, private route: ActivatedRoute) {
		
	}

	ngOnInit() {
		//this.event = this.eventService.getEvent(
		//+this.route.snapshot.params['id']
		//);
	}

	cancel() {
		
	}

	event : any;
	id: number;
}