using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public class DTONodes
    {
        public DTONodes PreviousNode { get; set; }
        public int Node_Kod { get; set; }
        public string Name_Node { get; set; }
        public int Value_X { get; set; }
        public int Value_Y { get; set; }

        public DTONodes()
        {

        }

        public DTONodes(Nodes n)
        {
            this.Node_Kod = Node_Kod;
            this.Name_Node = Name_Node;
            this.Value_X = Value_X;
            this.Value_Y = Value_Y;
        }

        public Nodes FromDTOToTable(DTONodes dt)
        {
            Nodes d = new Nodes();
            d.Node_Kod = dt.Node_Kod;
            d.Name_Node = dt.Name_Node;
            d.Value_X = dt.Value_X;
            d.Value_Y = dt.Value_Y;
            return d;
        }

        public static List<DTONodes> CreatDtoList(List<Nodes> d)
        {
            List<DTONodes> dtolist = new List<DTONodes>();
            foreach (var c in d)
            {
                DTONodes dTO = new DTONodes(c);
                dtolist.Add(dTO);
            }
            return dtolist;

        }
    }
    
}
