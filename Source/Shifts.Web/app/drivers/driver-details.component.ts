import { Component, OnInit } from '@angular/core'
import { ActivatedRoute } from '@angular/router'
import { DriverService  } from './driver.service'

@Component({
  templateUrl:'/app/drivers/driver-details.component.html',
  styles:[`
	.container { padding-left:20px; padding-right: 20px;}
	.driver-image: {height: 100px;}
  `]
})
export class DriverDetailsComponent implements  OnInit {
	
	constructor(private driverService: DriverService, private route: ActivatedRoute) {
		
	}

	ngOnInit() {
		this.driver = this.driverService.getDriver(
		+this.route.snapshot.params['id']
		);
	}

	driver : any;
	id: number;
}