import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent }  from './app.component';
import { EventsListComponent }  from './events-list.component';
import { EventThumbnailComponent} from './event-thumbnail.component'

@NgModule({
  imports:      [ BrowserModule ],
  declarations: [ AppComponent, EventsListComponent,EventThumbnailComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }


