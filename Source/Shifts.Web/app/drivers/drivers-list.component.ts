import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, CanActivate, Router } from '@angular/router'
import { ToastrService} from './../toastr.service'

import { DriverService} from './driver.service'
import { IDriver} from './driver.model'

@Component({
	moduleId: module.id,
	selector: 'drivers-list',
	template: `
			<div >
				<h1>Registrerede chauffører</h1>
				<hr>
				<div *ngFor="let driver of drivers">
					<driver-thumbnail (click)="handleClick(driver.name)" [driver]="driver"></driver-thumbnail>
				</div>
			</div>
	`
})
export class DriversListComponent implements OnInit {
	constructor(private driverService: DriverService, private toastrService: ToastrService, private route: ActivatedRoute) {
	}

	handleClick(data: string) {
		this.toastrService.success(data);
	}

	ngOnInit() {
		this.drivers = this.route.snapshot.data['drivers'];
	}

	drivers: IDriver[];
}