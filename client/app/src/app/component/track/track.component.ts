import { style } from '@angular/animations';
import { Location } from '@angular/common';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Locations } from 'src/app/model/Locations';
import { DbService } from 'src/app/services/db.service';



@Component({
  selector: 'app-track',
  templateUrl: './track.component.html',
  styleUrls: ['./track.component.css'],

})
export class TrackComponent implements OnInit {

  imageObj = new Image();
  imageName = "assets/מפה.png";

  shortestPath: any[] = [];
  @ViewChild('canvas', { static: true })
  canvas: any;
  @ViewChild('img', { static: true })
  img: any;
  private ctx: any;

  constructor(private router: Router, private dbService: DbService) {
    const x = this.router.getCurrentNavigation();
    this.shortestPath = dbService.myPath;
    console.log(this.shortestPath);
  }



  ngOnInit(): void {

    this.ctx = this.canvas.nativeElement.getContext('2d');
    this.imageObj.src = this.imageName;
    setTimeout(
      () => {

        this.ctx.drawImage(this.imageObj, 0, 0, 400, 300)
        console.log(this.imageObj);
      }
      , 1000);

    setTimeout(
      () => {
        const x1 = 30;
        const y1 = 40;
        const r = 50;
        const theta = 0.5;
        const point = this.shortestPath[0];
        this.ctx.moveTo(this.calcPointXToCanvas( point.X) ,this.calcPointYToCanvas(point.Y));

        for (let i = 1; i < this.shortestPath.length; i++) {
          const point = this.shortestPath[i];
          this.ctx.lineTo(this.calcPointXToCanvas( point.X) ,this.calcPointYToCanvas(point.Y));
        }

        this.ctx.stroke();
      }, 1500)
    // this.ctx.strokeStyle = 'red';
    // this.ctx.storkeWidth = 10;


    // this.ctx.beginPath();
    // this.ctx.moveTo(300, 300);
    // this.ctx.lineTo(400, 400);

    // this.ctx.stroke();
    // this.drawPath();

  }

  routing(nav: string) {
    let fullpath = 'app-list/' + nav
    this.router.navigate([fullpath])
  }

  drawStores(): void {
    this.ctx.drawImage(this.img, 0, 0);

  }
  drawPath(): void {

    this.ctx.beginPath();

    this.ctx.moveTo(this.shortestPath[0].X * 10, this.shortestPath[0].Y * 10);

    for (let i = 1; i < this.shortestPath.length; i++) {
      const point = this.shortestPath[i];
      this.ctx.lineTo(this.shortestPath[0].X * 10, this.shortestPath[0].Y * 10)
      console.log(this.shortestPath[0].X * 10, this.shortestPath[0].Y * 10);
    }
    this.ctx.strokeStyle = 'red';
    this.ctx.storkeWidth = 10;
    this.ctx.stroke();
  }

  calcPointXToCanvas(x: number) {
    console.log(x, "=>", (x *10));
    return 300-(x * 10);

  }

  calcPointYToCanvas(y: number) {
    console.log(y, "=>",  (y * 10));

    return 600- (y * 10);
  }

}


