import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Actor } from '../app/common/actor';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ActorService {
  private baseUrl = 'http://localhost:5001/api/actor';

  actors: Actor[];

  constructor(private httpClient: HttpClient) { }

  getActor(actorId: number): Observable<Actor> {

    const actorUrl = `${this.baseUrl}/get/${actorId}`;

    return this.httpClient.get<Actor>(actorUrl);
  }


  getActors(): Observable<Actor[]> {
    const searchUrl = `${this.baseUrl}/getAll`;
    return this.httpClient.get<Actor[]>(searchUrl);
   
  }

  deleteActor(actorId: number): void {

    const actorUrl = `${this.baseUrl}/delete/${actorId}`;

    this.httpClient.delete(actorUrl);
  }

  postActor(actorId: number): void {

    const actorUrl = `${this.baseUrl}/delete/${actorId}`;

    this.httpClient.delete(actorUrl);
  }

  putActor(actorId: number): void {

    const actorUrl = `${this.baseUrl}/delete/${actorId}`;

    this.httpClient.delete(actorUrl);
  }



}


interface GetResponseProducts {
  _embedded: {
    actors: Actor[];
  }
}
