import { Component, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PlayersProvider } from '../providers/PlayersProvider';
import { Players } from '../models/Players';
import { Router } from '@angular/router';
import { ConfirmationDialog } from '../dialog/dialog.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public playerList: Players[];

  //confirmation dialog for are you sure you want to delete
  @ViewChild('dialog') dialog: ConfirmationDialog;

  constructor(public http: HttpClient, private _playerProvider: PlayersProvider, private _router: Router) {
    this.playerList = [];
  }

  private currentPlayer: number;
  deleteDialog(id: number) {
    this.currentPlayer = id;
    this.dialog.open();
  }
  
  delete() {
    this._playerProvider.deletePlayer(this.currentPlayer).then(
      (data) => {
        this.getPlayers();
      })
  }

  getPlayers() {
    this._playerProvider.getPlayers().subscribe(
      data => this.playerList = data);
  }

  ngOnInit() {
    this.getPlayers();
  }

}
