import { Injectable, Inject } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Players } from '../models/Players';

@Injectable()
export class PlayersProvider {
  PingPongWebApplicationUrl: string = "";

  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.PingPongWebApplicationUrl = baseUrl;
  }

  getPlayers() {
    return this._http.get<Players[]>(this.PingPongWebApplicationUrl + 'api/Home/Index');
  }

  getPlayerById(id: number) {
    return this._http.get(this.PingPongWebApplicationUrl + 'api/Home/' + id);
  }

  savePlayer(player: Players) {
    return this._http.post(this.PingPongWebApplicationUrl + 'api/Home', player).toPromise();
  }

  updatePlayer(id: number, player: Players) {
    return this._http.put(this.PingPongWebApplicationUrl + 'api/Home/' + id, player).toPromise();
  }

  deletePlayer(id: number) {
    return this._http.delete(this.PingPongWebApplicationUrl + 'api/Home/' + id).toPromise();
  }

  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }
}


