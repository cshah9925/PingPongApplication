import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Players } from '../models/Players';
import { PlayersProvider } from '../providers/PlayersProvider';
import { FormGroup, ReactiveFormsModule, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-add-player',
  templateUrl: './add-player.component.html'
})
export class AddPlayerComponent implements OnInit {
  player: Players;
  id: number;
  title: string = "Add";
  playerForm: FormGroup;
  skillLevels: string[];
  errors: string[];

  constructor(private _fb: FormBuilder, public http: HttpClient, private _playerProvider: PlayersProvider,
    private _router: Router, private _avRoute: ActivatedRoute) {
    if (this._avRoute.snapshot.params["id"]) {
      this.id = this._avRoute.snapshot.params["id"];
    }

    this.player = new Players();
    this.playerForm = this._fb.group({
      'id': 0,
      'firstName': new FormControl('', [Validators.required]),
      'lastName': new FormControl('', [Validators.required]),
      'age': new FormControl(''),
      'skillLevel': new FormControl('', [Validators.required]),
      'email': new FormControl('', [Validators.required])
    });

    this.skillLevels = new Array('Beginner', 'Intermediate', 'Advanced', 'Expert');
  }

  ngOnInit() {
    if (this.id > 0) {
      this.title = "Edit";
      this._playerProvider.getPlayerById(this.id)
        .subscribe(resp => this.playerForm.setValue(resp));
    }
    this.errors = [];
  }

  save() {

    if (this.playerForm.valid) {
      if (this.title == "Add") {
        this._playerProvider.savePlayer(this.playerForm.value)
          .then((data) => {
            this.player = data as Players;
            this._router.navigate(['/home']);
          });
      }
      else if (this.title == "Edit" && this.id > 0) {
        this._playerProvider.updatePlayer(this.id, this.playerForm.value)
          .then((data) => {
            this.player = data as Players;
            this._router.navigate(['/home']);
          });
      }
    }
    else {
      this.errors.push("Something went wrong");
    }

    }
  }
