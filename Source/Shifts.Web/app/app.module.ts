import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router'
import { HttpModule } from '@angular/http'

import { AppComponent } from './app.component';

import { DriversListComponent } from './drivers/drivers-list.component';
import { DriverThumbnailComponent} from './drivers/driver-thumbnail.component'
import { DriverService } from './drivers/driver.service'
import { DriverDetailsComponent } from './drivers/driver-details.component'
import { CreateDriverComponent } from './drivers/create-driver.component'
import { DriversListResolverService } from './drivers/drivers-list-resolver.service'
import { DriverRouteActivator } from './drivers/driver-route-activator.service'

import { ToastrService} from './toastr.service'
import { NavBarComponent } from './navbar.component'
import { Error404Component } from './404.component'

import { appRoutes } from './routes'
import { Routes } from '@angular/router'

@NgModule({
	imports: [BrowserModule, RouterModule.forRoot(appRoutes), HttpModule ],
	declarations: [
		AppComponent, DriversListComponent, DriverThumbnailComponent, NavBarComponent,
		DriverDetailsComponent, CreateDriverComponent, Error404Component
	],
	providers: [
		DriverService,
		ToastrService,
		DriverRouteActivator,
		DriversListResolverService,
		{
			provide: 'canDeactivateCreateDriver',
			useValue: checkDirtyState
		}
	],
	bootstrap: [AppComponent]
})
export class AppModule {
}

function checkDirtyState(component: CreateDriverComponent) {
	if (component.isDirty) {
		return window.confirm('You have unsaved changes, really cancel?');
	}
	return true;
}