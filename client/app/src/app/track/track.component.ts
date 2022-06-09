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
//   drawShop()
// {
  
//   let s:Shop=this.db.getShop();
//   //drow walls:
//   // ------------------
//   this.ctx.fillStyle = "rgb(185, 185, 183)";
//   let ws:Wall[]=s.Walls;
//   for(let i:number=0; i<ws.length; i++)
//   {
//     let wal:Wall=ws[i];
//     let p1:Point=wal.P1;
//     let p2:Point=wal.P2;
//     let w=(p2.X-p1.X+1)*this.mul;
//     let h=(p2.Y-p1.Y+1)*this.mul;
//     this.ctx.fillRect (p1.X*this.mul, p1.Y*this.mul,w , h);
//     let squre:Square=new Square(this.ctx);
//     squre.draw(p1.X*this.mul,p1.Y*this.mul, w,h,"rgb(185, 185, 183)");
//   }

//   //drow stands
//   // ------------------
//   this.ctx.fillStyle = "rgb(146, 146, 146)";
//   for(let i:number=0; i<s.Stands.length; i++)
//   {
//     let st:Stand=s.Stands[i];
//     let p1:Point=st.P1;
//     let p2:Point=st.P2;
//     let w=(p2.X-p1.X+1)*this.mul;
//     let h=(p2.Y-p1.Y+1)*this.mul;
//     this.ctx.fillRect (p1.X*this.mul,p1.Y*this.mul, w,h );
//     // 3d
//     let squre:Square=new Square(this.ctx);
//     squre.draw(p1.X*this.mul,p1.Y*this.mul, w,h,"rgb(108, 109, 108)");
//     // stroke
//     this.ctx.strokeStyle ="rgb(108, 109, 108)";
//     this.ctx.lineWidth   =1;
//     this.ctx.strokeRect(p1.X*this.mul,p1.Y*this.mul, w,h);
//   }
// }



}


