import { KeyValuePair } from './../models/keyValuePair';
import { StampService } from './../services/stamp.service';
import { Component, OnInit } from '@angular/core';
import { Stamp } from '../models/stamp';

@Component({
  selector: 'app-stamp-list',
  templateUrl: './stamp-list.component.html',
  styleUrls: ['./stamp-list.component.css']
})
export class StampListComponent implements OnInit {
  stamps: Stamp[];
  continents: KeyValuePair[];
  countries: KeyValuePair[];
  filter:any = {};
  selectedContinentId: number;
  selectedCountryId: number;

  constructor(private stampService: StampService) { }

  ngOnInit() {
    this.stampService.getContinents().subscribe(
      cList => this.continents = <KeyValuePair[]>cList
    );

    this.stampService.getCountries().subscribe(
      cList => this.countries = <KeyValuePair[]>cList
    );

    this.loadStamps();
  }

  loadStamps() {
    this.stampService.loadAll(this.filter).subscribe(
      sList => this.stamps = <Stamp[]>sList
    );
  }

  onFilterChange() {
    this.loadStamps();
  }

  resetFilter() {
    this.filter = {};
    this.onContinentChange();
    this.onFilterChange();
  }

  onContinentChange() {
    this.selectedContinentId = this.filter.continentId;
    this.bindCountries();
  }

  onCountryChange() {
    this.selectedCountryId = this.filter.countryId;
    this.bindContinents();
  }

  private bindCountries() {
    var selectedContinent: any = this.continents.find(c => c.id == this.selectedContinentId);
    this.countries = selectedContinent ? selectedContinent.countries : [];
    delete this.filter.countryId;
  }

  private bindContinents() {
    var selectedCountry: any = this.countries.find(c => c.id == this.selectedCountryId);
    //this.selectedContinentId = selectedCountry ? selectedCountry.continentId : 0;
  }

}
