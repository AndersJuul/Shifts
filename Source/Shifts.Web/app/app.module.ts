import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { EventsListComponent } from './events-list.component';
import { EventThumbnailComponent} from './event-thumbnail.component'
import { EventService } from './event.service'
import { ToastrService} from './toastr.service'
import { NavBarComponent } from './navbar.component'

@NgModule({
	imports: [BrowserModule],
	declarations: [AppComponent, EventsListComponent, EventThumbnailComponent, NavBarComponent ],
	providers: [EventService, ToastrService],
	bootstrap: [AppComponent]
})
export class AppModule {
}