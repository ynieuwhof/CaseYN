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
    this.httpClient.get<Cursus[]>('https://localhost:44371/api/cursussen').subscribe((cursus) => {
      this.cursussen = cursus;
      this.cursussen = this.sortDates(this.cursussen);
    });
  }

  sortDates(cursusLijst) {
    return cursusLijst.sort((a: any, b: any) => 
    new Date(a.startDatum).getTime() - new Date(b.startDatum).getTime()
    );
  }
}
