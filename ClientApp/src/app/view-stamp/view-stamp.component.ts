import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StampService } from '../services/stamp.service';

@Component({
  selector: 'app-view-stamp',
  templateUrl: './view-stamp.component.html',
  styleUrls: ['./view-stamp.component.css']
})
export class ViewStampComponent implements OnInit {
  stamp: any;
  stampId: number;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private stampService: StampService) {
    route.params.subscribe(p => {
      this.stampId = +p['id'];
      if (isNaN(this.stampId) || this.stampId <= 0) {
        router.navigate(['/stamps']);
        return;
      }
    });
  }

  ngOnInit() {
    this.stampService.load(this.stampId)
      .subscribe(
        s => this.stamp = s,
        err => {
          if (err.status == 404) {
            this.router.navigate(['/stamps']);
            return;
          }
        });
  }

  delete() {
    if (confirm("Do you want to delete this stamp?")) {
      this.stampService.delete(this.stamp.id)
        .subscribe(s => {
          this.router.navigate(['/stamps']);
        });
    }
  }

}
