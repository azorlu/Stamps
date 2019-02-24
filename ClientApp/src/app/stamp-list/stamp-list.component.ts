import { KeyValuePair } from './../models/keyValuePair';
import { StampService } from './../services/stamp.service';
import { Component, OnInit } from '@angular/core';
import { Stamp } from '../models/stamp';
import { faSearch, faSortUp, faSortDown } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-stamp-list',
  templateUrl: './stamp-list.component.html',
  styleUrls: ['./stamp-list.component.css']
})
export class StampListComponent implements OnInit {
  private readonly PAGE_SIZE = 3;

  faSearch = faSearch;
  faSortUp = faSortUp;
  faSortDown = faSortDown;

  queryResult:any = {};
  continents: KeyValuePair[];
  countries: KeyValuePair[];
  query:any = {
    pageSize: this.PAGE_SIZE
  };
  selectedContinentId: number;
  selectedCountryId: number;

  columns = [
    { title: 'Id' },
    { title: 'Title', key: 'title', isSortable: true },
    { title: 'Category', key: 'category', isSortable: true },
    { title: 'Continent', key: 'continent', isSortable: true }, 
    { title: 'Country', key: 'country', isSortable: true },
    { title: 'View' }
  ];

  constructor(private stampService: StampService) { }

  ngOnInit() {
    this.stampService.getContinents().subscribe(
      c => this.continents = <KeyValuePair[]>c
    );

    this.stampService.getCountries().subscribe(
      c => this.countries = <KeyValuePair[]>c
    );

    this.loadStamps();
  }

  loadStamps() {
    this.stampService.loadAll(this.query).subscribe(
      result => this.queryResult = result
    );
  }

  onQueryChange() {
    this.query.page = 1;
    this.loadStamps();
  }

  resetQuery() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    this.onContinentChange();
    //this.onQueryChange();
    this.loadStamps();
  }

  onContinentChange() {
    this.selectedContinentId = this.query.continentId;
    this.bindCountries();
  }

  onCountryChange() {
    this.selectedCountryId = this.query.countryId;
    this.bindContinents();
  }

  private bindCountries() {
    var selectedContinent: any = this.continents.find(c => c.id == this.selectedContinentId);
    this.countries = selectedContinent ? selectedContinent.countries : [];
    delete this.query.countryId;
  }

  private bindContinents() {
    var selectedCountry: any = this.countries.find(c => c.id == this.selectedCountryId);
  }

  sortBy(columnName) {
    if (this.query.sortBy === columnName) {
      this.query.isSortAscending = !this.query.isSortAscending;
    } else {
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }
    this.loadStamps();
  }

  onPageChange(page) {
    this.query.page = page;
    this.loadStamps();
  }

}
