import { Component } from '@angular/core';

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
export class EventsListComponent {
	events = [
	{
		id:1,
		name: 'Angular connect',
		date: '2017-02-21',
		time: '20:00',
		price: 199.99,
		imageUrl:'/app/assets/images/angularconnect'
		},
	{
		id:2,
		name: 'Angular more',
		date: '2017-03-21',
		time: '15:00',
		price: 299.99,
		imageUrl:'/app/assets/images/angularconnect'
		}
		]
}