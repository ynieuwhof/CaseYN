# CaseYN

Backend:
  - Het target framework van dit project is net 5.0
  - Controleer de connection string in de appsettings.json file en verander die eventueel naar de gewenste locatie 
    - Zorg ervoor dat indien je de naam heb veranderd van de connectionstring deze ook overeenkomt met de naam die in de startup.cs file staat 
  - Build als eerst de solution zodat de benodigde nuget packages worden toegevoegd
  - Ga naar de package manager console en voer de command Update-Database uit
  - Run de solution 
    - Controleer of database is gemaakt en gevuld is met de seed data
  
Frontend:
 - Open een terminal en controleer of je in de map "administratie-app" zit
 - Voer het command "npm install" uit
 - Als deze klaar is kan je de applicatie starten met "ng serve", navigeer vervolgens naar http://localhost:4200 
  - Het is handig om eerst de c#-applicatie te runnen anders ziet de frontend er een beetje leeg uit
 - Om de test te draaien voer je het command "ng test" uit
