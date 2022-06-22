using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL.BSD
{
    class Vertax
    {
       public Nodes IDNodes { get; set; }
       public Nodes vertexColumn { get; set; }
       public Nodes nodeIsViseted { get; set; }
       public Nodes nodeName { get; set; }
       public  Nodes nodePreviousNode { get; set; }
       public Nodes vertexRow { get; set; }
       public Nodes nodeValue { get; set; }

        public Vertax(Nodes IDNodes, Nodes vertexColumn, Nodes nodeIsViseted, Nodes nodeName, Nodes nodePreviousNode, Nodes vertexRow, Nodes nodeValue)
        {
            this.IDNodes = IDNodes;
            this.vertexColumn = vertexColumn;
            this.nodeIsViseted = nodeIsViseted;
            this.nodeName = nodeName;
            this.nodePreviousNode = nodePreviousNode;
            this.vertexRow = vertexRow;
            this.nodeValue = nodeValue;
        }

    }
}
