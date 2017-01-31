import { Component, OnInit } from '@angular/core';
import { EventService} from './event.service'

@Component({
	moduleId: module.id,
	selector: 'events-list',
	template: `
			<div>
				<h1>Upcoming Angular 2 Events</h1>
				<hr>
				<div *ngFor="let event of events">
					<event-thumbnail [event]="event"></event-thumbnail>
				</div>
			</div>
	`
})
export class EventsListComponent implements  OnInit {
	constructor(private eventService: EventService) {
	}

	ngOnInit() {
		this.events = this.eventService.getEvents();
		this.stuff = 0;
	}

	events: any[];
	stuff: number;
}