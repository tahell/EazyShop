import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-track',
  templateUrl: './track.component.html',
  styleUrls: ['./track.component.css'],
//   template: `
//   <canvas #canvas width="600" height="300"></canvas>
//   <button (click)="animate()">Play</button>   
// `,
// styles: ['canvas { border-style: solid }']
})

// @ViewChild('canvas', { static: true }) 

export class TrackComponent implements OnInit  {
  // @ViewChild('canvas', { static: true })
  // // canvas: ElementRef<HTMLCanvasElement>;  
  
  // private ctx: CanvasRenderingContext2D;
  
  constructor() { }

  
  ngOnInit(): void {
    // var canvas = <HTMLCanvasElement> $('#example').find('canvas').get(0);
    // var ctx = <CanvasRenderingContext2D>this.canvas.nativeElement.getContext('2d');
  }
  // animate(): void {}
}
