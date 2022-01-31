import { Component, Inject, OnInit } from '@angular/core';
import { ActorService } from 'src/services/actor.service';
import { Actor } from 'src/app/common/actor';
import { HttpClient } from '@angular/common/http';
import { observable, Observable } from 'rxjs';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  actors: Actor[] = [];
  constructor(private actorService: ActorService) {

  }

}
