using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dijxtra
{
    public class Algorithm
    {
        static DBConection db = new DBConection();

        public List<DTONodes> CreateShortestRouteOnStore(List<DTOProduct> pl)
        {
            List<DTONodes> DtoNodesList = new List<DTONodes>();
            List<Products> productsList = db.GetDbSet<Products>().Where(p => pl.FirstOrDefault(p1 => p1.Product_code == p.Product_Code) != null).ToList();


            List<Nodes> nodesList = ConvertProductToNodes(productsList);
            DtoNodesList = CreatDtoList(nodesList);
            return DtoNodesList;
        }


        public List<Nodes> ConvertProductToNodes(List<Products> lp)
        {
            List<Products> productsList = new List<Products>();
            List<Nodes> nodesList = new List<Nodes>();

            foreach (var p in productsList)
            {
                Nodes node;
                if (p.Columns.StartOrEnd == false) //התחלה - 1
                {
                    node = p.Columns.Transition.Nodes;
                }
                else
                {
                    node = p.Columns.Transition.Nodes1;
                }
                nodesList.Add(node);
            }

            return nodesList;
        }


      
    }
}
