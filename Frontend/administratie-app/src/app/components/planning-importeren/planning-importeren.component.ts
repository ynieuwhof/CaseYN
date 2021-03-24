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
  showMessage = false;


  result: any;

  handleFileUpload(){
    let fileReader = new FileReader();
    fileReader.onload = (e) => {
      this.result = fileReader.result.toString().split("\n\n");
      this.result.pop();
      console.log(this.result);
      this.httpClient.post("https://localhost:44371/api/import", this.result).subscribe((response) => {
        console.log(response);
        this.aantalCursussen = response["toegevoegdeCursussen"];
        this.aantalInstanties = response["toegevoegdeInstanties"];
        this.showMessage = true;
      })
    }
    fileReader.readAsText(this.file);;
  }

  file: any;

  fileChanged(e) {
    this.file = e.target.files[0];
  }

}
