import { HttpClient } from '@angular/common/http';
import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'planning-importeren',
  templateUrl: './planning-importeren.component.html',
  styleUrls: ['./planning-importeren.component.css']
})
export class PlanningImporterenComponent implements OnInit {

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
  }

  aantalCursussen: number;
  aantalInstanties: number;
  aantalDuplicaten: number;
  showMessage = false;
  showDuplicateMessage = false;
  errorMessage: string;

  result: Array<string>;


  handleFileUpload(){
    let fileReader = new FileReader();
    fileReader.onload = (e) => {
      this.result = [fileReader.result.toString()];

      this.httpClient.post("https://localhost:44371/api/import", this.result).subscribe((response) => {
        this.aantalCursussen = response["toegevoegdeCursussen"];
        this.aantalInstanties = response["toegevoegdeInstanties"];
        this.aantalDuplicaten = response["aantalDuplicaten"];
        this.errorMessage = response["errorMessage"];
        this.toggleMessages();    
      }) 
    }
    fileReader.readAsText(this.file);;
  }

  toggleMessages() {
    if (this.aantalDuplicaten > 0) {
      this.showDuplicateMessage = true;
    }
    else {
      this.showDuplicateMessage = false;
    }
    if(this.aantalCursussen > 0 || this.aantalInstanties > 0) {
      this.showMessage = true;
    }
    else {
      this.showMessage = false;
    }
  }

  file: any;

  fileChanged(e) {
    this.file = e.target.files[0];
  }

}
