import { Component, OnInit } from '@angular/core'
import { DriverService  } from './driver.service'
import { Router } from '@angular/router'

@Component({
  templateUrl:'/app/drivers/create-driver.component.html',
  styles:[`
	.container { padding-left:20px; padding-right: 20px;}
	.event-image: {height: 100px;}
  `]
})
export class CreateDriverComponent implements  OnInit {
	isDirty:boolean=true;
	constructor(private driverService: DriverService, private router: Router) {
		
	}

	ngOnInit() {
		//this.event = this.eventService.getDriver(
		//+this.route.snapshot.params['id']
		//);
	}

	cancel() {
		this.router.navigate(['/driver'])
	}

	driver : any;
	id: number;
}