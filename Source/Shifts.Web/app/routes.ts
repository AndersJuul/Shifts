import { Routes } from '@angular/router'
import { EventDetailsComponent } from './event-details.component'
import { EventsListComponent } from './events-list.component';
import { CreateEventComponent } from './create-event.component'
import { Error404Component } from './404.component'
import { EventRouteActivator } from './event-route-activator.service'

export const appRoutes: Routes = [
	{ path: 'events', component: EventsListComponent },
	{ path: 'events/new', component: CreateEventComponent, canDeactivate: ['canDeactivateCreateEvent'] },
	{ path: 'events/:id', component: EventDetailsComponent, canActivate: [EventRouteActivator] },
	{ path: '404', component: Error404Component },
	{ path: '', redirectTo: '/events', pathMatch: 'full' }
]