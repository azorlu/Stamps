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
  currentYear:number;
  title:string;
  description:string;
  stamp: any= {};
  
  constructor(private stampService: StampService) { 
      
    }

  ngOnInit() {
    this.currentYear = new Date().getFullYear();
    
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
    var selectedContinent = this.continents.find(c => c.id == this.stamp.continentId);
    this.countries = selectedContinent ? selectedContinent.countries : [];
    delete this.stamp.countryId;
  }

  onCategoryChange(c) {
    this.stamp.categoryId = c.id;
  }

  submit() {
    this.stampService.create(this.stamp)
     .subscribe(s => console.log(s));
  }

}
