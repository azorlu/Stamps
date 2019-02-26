
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StampService } from '../services/stamp.service';
import { PhotoService } from '../services/photo.service';

@Component({
  selector: 'app-view-stamp',
  templateUrl: './view-stamp.component.html',
  styleUrls: ['./view-stamp.component.css']
})
export class ViewStampComponent implements OnInit {
  @ViewChild('fileInput') fileInput: ElementRef
  stamp: any;
  stampId: number;
  photos;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private photoService: PhotoService,
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
    this.photoService.loadByStampId(this.stampId)
      .subscribe(p => this.photos = p);

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

  uploadPhoto() {
    var elem: HTMLInputElement = this.fileInput.nativeElement;

    this.photoService.upload(this.stampId, elem.files[0])
      .subscribe(p => {
        this.photos.push(p);
      });
  }

}
