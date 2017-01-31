import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent }  from './app.component';
import { EventsListComponent }  from './events-list.component';
import { EventThumbnailComponent} from './event-thumbnail.component'
import { EventService } from './event.service'


@NgModule({
  imports:      [ BrowserModule ],
  declarations: [ AppComponent, EventsListComponent,EventThumbnailComponent ],
  providers:    [ EventService ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }


