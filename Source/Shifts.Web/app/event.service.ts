import { Injectable, EventEmitter } from '@angular/core'
import { Subject, Observable } from 'rxjs/RX'
import { IEvent } from './event.model'
import { Http, Response } from '@angular/http'


@Injectable()
export class EventService {
	constructor(private http: Http) {}

	getEvents(): Observable<IEvent[]> {
		return this.http.get("/api/drivers")
			.map(this.extractData)
			.catch(this.handleError);
	}

	getEvent(id: number) {
		return EVENTS.find(event => event.id === id);
	}

	private extractData(res: Response) {
		let body = <IEvent[]> res.json();
		return body || {};
	}

	private handleError(error: Response | any) {
		// In a real world app, we might use a remote logging infrastructure
		let errMsg: string;
		if (error instanceof Response) {
			const body = error.json() || '';
			const err = body.error || JSON.stringify(body);
			errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
		} else {
			errMsg = error.message ? error.message : error.toString();
		}
		console.error(errMsg);
		return Observable.throw(errMsg);
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