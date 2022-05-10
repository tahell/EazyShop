using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dijxtra
{
    public class Route
    {
       public Nodes source { get; set; }
        public Nodes destination { get; set; }
        public double value { get; set; }

        public Route(Nodes source, Nodes destination, double value)
        {
            this.source = source;
            this.destination = destination;
            this.value = value;


        }
    }
}
