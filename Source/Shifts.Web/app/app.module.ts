import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router'

import { AppComponent } from './app.component';
import { EventsListComponent } from './events-list.component';
import { EventThumbnailComponent} from './event-thumbnail.component'
import { EventService } from './event.service'
import { ToastrService} from './toastr.service'
import { NavBarComponent } from './navbar.component'
import { EventDetailsComponent } from './event-details.component'
import { appRoutes } from './routes'
import { Routes } from '@angular/router'

@NgModule({
	imports: [BrowserModule, RouterModule.forRoot(appRoutes)],
	declarations: [AppComponent, EventsListComponent, EventThumbnailComponent, NavBarComponent,EventDetailsComponent ],
	providers: [EventService, ToastrService],
	bootstrap: [AppComponent]
})
export class AppModule {
}