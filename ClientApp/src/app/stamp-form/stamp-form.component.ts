import { ContinentService } from './../services/continent.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-stamp-form',
  templateUrl: './stamp-form.component.html',
  styleUrls: ['./stamp-form.component.css']
})
export class StampFormComponent implements OnInit {

  continents;
  countries;
  stamp: any= {};
  
  constructor(private continentService: ContinentService) { }

  ngOnInit() {
    this.continentService.getContinents()
      .subscribe(continents => {
        this.continents = continents;
        console.log("CONTINENTS", this.continents);
      });
  }

  onContinentChange() {
    //console.log("Stamp", this.stamp);
    var selectedContinent = this.continents.find(c => c.id == this.stamp.continent);
    this.countries = selectedContinent ? selectedContinent.countries : [];
  }

}
