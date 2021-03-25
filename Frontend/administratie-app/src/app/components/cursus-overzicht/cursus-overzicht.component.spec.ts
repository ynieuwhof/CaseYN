import {CursusOverzichtComponent} from "./cursus-overzicht.component";
import {Cursus} from '../../models/Cursus';
import { TestBed } from "@angular/core/testing";
import { HttpClientModule} from '@angular/common/http';

describe('Component: CursusOverzicht', () => {
    let sut : CursusOverzichtComponent;

    beforeEach(() => {
        TestBed.configureTestingModule({
            declarations: [CursusOverzichtComponent],
                imports: [
                    HttpClientModule
                ]
        });
        sut = TestBed.createComponent(CursusOverzichtComponent).componentInstance;
    })

    let cursussen = [
        {startDatum: new Date(2020, 1, 5), Duur: 3, Titel : "test", InstantieId : 2},
        {startDatum: new Date(2020, 1, 4), Duur: 3, Titel : "test", InstantieId : 2},
        {startDatum: new Date(2020, 1, 1), Duur: 3, Titel : "test", InstantieId : 2},
        {startDatum: new Date(2020, 1, 2), Duur: 3, Titel : "test", InstantieId : 2}
    ];

    let verwachteOutput = [
        {startDatum: new Date(2020, 1, 1), Duur: 3, Titel : "test", InstantieId : 2},
        {startDatum: new Date(2020, 1, 2), Duur: 3, Titel : "test", InstantieId : 2},
        {startDatum: new Date(2020, 1, 4), Duur: 3, Titel : "test", InstantieId : 2},
        {startDatum: new Date(2020, 1, 5), Duur: 3, Titel : "test", InstantieId : 2}
    ];

    it('should sort the array by date', () => {
        let output = sut.sortDates(cursussen);
        expect(output).toEqual(verwachteOutput);
    });

});