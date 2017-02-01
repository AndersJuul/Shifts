import { Injectable } from '@angular/core'
import { Subject } from 'rxjs/RX'

@Injectable()
export class EventService {
	getEvents() {
		let subject = new Subject();
		setTimeout(() => {
			subject.next(EVENTS);
			subject.complete();
		}, 
		100);
		return subject;
	}

	getEvent(id: number) {
		return EVENTS.find(event => event.id === id);
	}
}

const EVENTS =
[
	{
		id: 1,
		name: 'Angular connect',
		date: '2017-02-21',
		time: '20:00',
		price: 199.99,
		imageUrl: '/app/assets/images/angularconnect'
	},
	{
		id: 2,
		name: 'Angular more',
		date: '2017-03-21',
		time: '15:00',
		price: 299.99,
		imageUrl: '/app/assets/images/angularconnect'
	},
	{
		id: 3,
		name: 'Angular encore',
		date: '2017-05-25',
		time: '17:00',
		price: 199.99,
		imageUrl: '/app/assets/images/angularencore'
	}
]