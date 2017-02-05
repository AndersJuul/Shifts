import { Injectable } from '@angular/core'
import { Resolve } from '@angular/router'
import { DriverService } from './driver.service'

@Injectable()
export class DriversListResolverService implements Resolve<any> {
	constructor(private driverService: DriverService) {
	}
	resolve() {
		return this.driverService.getDrivers().map(drivers => drivers);
	}
}

