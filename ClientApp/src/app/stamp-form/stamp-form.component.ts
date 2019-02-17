import { StampService } from '../services/stamp.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-stamp-form',
  templateUrl: './stamp-form.component.html',
  styleUrls: ['./stamp-form.component.css']
})
export class StampFormComponent implements OnInit {

  continents;
  countries;
  categories;
  stamp: any= {};
  
  constructor(private stampService: StampService) { 

    }

  ngOnInit() {
    this.stampService.getContinents()
      .subscribe(continents => {
        this.continents = continents;
      });

      this.stampService.getCategories()
      .subscribe(categories => {
        this.categories = categories;
      });
  }

  onContinentChange() {
    //console.log("Stamp", this.stamp);
    var selectedContinent = this.continents.find(c => c.id == this.stamp.continent);
    this.countries = selectedContinent ? selectedContinent.countries : [];
  }

}
