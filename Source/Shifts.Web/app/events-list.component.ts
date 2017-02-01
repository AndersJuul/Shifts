import { Component, OnInit } from '@angular/core';
import { EventService} from './event.service'
import { ToastrService} from './toastr.service'
import { ActivatedRoute, CanActivate,Router } from '@angular/router'

@Component({
	moduleId: module.id,
	selector: 'events-list',
	template: `
			<div>
				<h1>Upcoming Angular 2 Events</h1>
				<hr>
				<div *ngFor="let event of events">
					<event-thumbnail (click)="handleClick(event.name)" [event]="event"></event-thumbnail>
				</div>
			</div>
	`
})
export class EventsListComponent implements  OnInit {
	constructor(private eventService: EventService, private toastrService: ToastrService, private route: ActivatedRoute) {
	}

	handleClick(data:string) {
		this.toastrService.success(data);
	}

	ngOnInit() {
		this.events = this.route.snapshot.data['events'];
	}

	events: any;
}