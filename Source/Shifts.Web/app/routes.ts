import { Routes } from '@angular/router'
import { DriverDetailsComponent } from './drivers/driver-details.component'
import { DriversListComponent } from './drivers/drivers-list.component';
import { CreateDriverComponent } from './drivers/create-driver.component'
import { Error404Component } from './404.component'
import { DriverRouteActivator } from './drivers/driver-route-activator.service'
import { DriversListResolverService } from './drivers/drivers-list-resolver.service'

export const appRoutes: Routes = [
	{ path: 'drivers', component: DriversListComponent, resolve: {drivers:DriversListResolverService} },
	{ path: 'drivers/new', component: CreateDriverComponent, canDeactivate: ['canDeactivateCreateDriver'] },
	{ path: 'drivers/:id', component: DriverDetailsComponent, canActivate: [DriverRouteActivator] },
	{ path: '404', component: Error404Component },
	{ path: '', redirectTo: '/drivers', pathMatch: 'full' }
]