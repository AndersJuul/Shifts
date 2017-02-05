import { Injectable } from '@angular/core'
import { ActivatedRouteSnapshot, CanActivate,Router } from '@angular/router'

import { DriverService } from './driver.service'

@Injectable()
export class DriverRouteActivator implements CanActivate {
	constructor(private driverService: DriverService, private router:Router) {
	}

	canActivate(route: ActivatedRouteSnapshot) {
		const driverExists = !! this.driverService.getDriver(+route.params['id']);
		if (!driverExists) {
			this.router.navigate(['/404']);
		}
		return driverExists;
	}
}