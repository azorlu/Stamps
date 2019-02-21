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
  filter:any = {};

  constructor(private stampService: StampService) { }

  ngOnInit() {
    this.stampService.getContinents().subscribe(
      cList => this.continents = <KeyValuePair[]>cList
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
    this.onFilterChange();
  }
}
