import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {Cursus} from '../../models/Cursus';

@Component({
  selector: 'cursus-overzicht',
  templateUrl: './cursus-overzicht.component.html',
  styleUrls: ['./cursus-overzicht.component.css']
})
export class CursusOverzichtComponent implements OnInit {

  constructor(private httpClient: HttpClient) { }

  cursussen: Cursus[];

  ngOnInit(): void {
    this.httpClient.get<Cursus[]>('https://localhost:44371/api/cursus/alle').subscribe((cursus) => {
      this.cursussen = cursus;
    });
  }

}
