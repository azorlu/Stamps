import { SaveStamp } from './../models/saveStamp';
import { StampService } from '../services/stamp.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { forkJoin } from 'rxjs';
import { Stamp } from '../models/stamp';

@Component({
  selector: 'app-stamp-form',
  templateUrl: './stamp-form.component.html',
  styleUrls: ['./stamp-form.component.css']
})
export class StampFormComponent implements OnInit {

  continents;
  countries;
  categories;
  currentYear: number;
  title: string;
  description: string;
  stamp: SaveStamp = {
    id: 0,
    continentId: 0,
    countryId: 0,
    categoryId: 0,
    yearIssued: 2000,
    title: "",
    description: ""
  };
  loadStamp: boolean;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private stampService: StampService) {
    route.params.subscribe(p => {
      this.stamp.id = +p['id']; // add + to convert value to number
    })
  }

  ngOnInit() {
    this.currentYear = new Date().getFullYear();

    this.loadStamp = this.stamp.id ? true : false;

    var dataSources = [
      this.stampService.getContinents(),
      this.stampService.getCategories()
    ];

    if (this.loadStamp) {
      dataSources.push(this.stampService.load(this.stamp.id));
    }

    forkJoin(dataSources)
      .subscribe(data => {
        this.continents = data[0];
        this.categories = data[1];
        if (this.loadStamp) {
          this.setStamp(<Stamp>data[2]);
          this.bindCountries();
        }
      }, err => {
        this.router.navigate(['/']);
      });
  }

  private setStamp(s: Stamp) {
    this.stamp.id = s.id;
    this.stamp.continentId = s.continent.id;
    this.stamp.countryId = s.country.id;
    this.stamp.categoryId = s.category.id;
    this.stamp.yearIssued = s.yearIssued;
    this.stamp.title = s.title;
    this.stamp.description = s.description;
  }

  onContinentChange() {
    this.bindCountries();
    delete this.stamp.countryId;
  }

  private bindCountries() {
    var selectedContinent = this.continents.find(c => c.id == this.stamp.continentId);
    this.countries = selectedContinent ? selectedContinent.countries : [];
  }

  private backToSearch() {
    this.router.navigate(['/stamps']);
  }

  submit() {
    if (this.loadStamp) {
      this.stampService.update(this.stamp)
        .subscribe(s => this.backToSearch()
        );
    } else {
      this.stamp.id = 0; // if id is NaN BAD REQUEST error occurs
      this.stampService.create(this.stamp)
        .subscribe(s => this.backToSearch()
        );
    }
  }

  delete() {
    if (confirm('Do you want to delete this stamp?')) {
      this.stampService.delete(this.stamp.id)
      .subscribe(d => {
        this.router.navigate(['/']);
      })
    }
  }
}
