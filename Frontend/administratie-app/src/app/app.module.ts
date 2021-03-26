import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CursusOverzichtComponent } from './components/cursus-overzicht/cursus-overzicht.component';
import  { HttpClientModule} from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PlanningImporterenComponent } from './components/planning-importeren/planning-importeren.component';

const appRoutes: Routes = [
  {path: '', component: CursusOverzichtComponent},
  {path: 'cursus-overzicht', component: CursusOverzichtComponent},
  {path: 'cursus-toevoegen', component: PlanningImporterenComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    CursusOverzichtComponent,
    PlanningImporterenComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
