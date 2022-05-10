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

        public static List<object> CreateShortestRouteOnStore(List<DTOProduct> pl)
        {
            List<DTONodes> dtoNodesList = new List<DTONodes>();
            List<Products> productsList = db.GetDbSet<Products>().Where(p => pl.FirstOrDefault(p1 => p1.Product_code == p.Product_Code) != null).ToList();


            List<Nodes> nodesList = ConvertProductToNodes(productsList);



            return null;
        }


        public static List<Nodes> ConvertProductToNodes(List<Products> lp)
        {
            List<Products> productsList = new List<Products>();
            List<Nodes> nodesList = new List<Nodes>();

            foreach (var p in productsList)
            {
                Nodes node;
                if (p.Columns.Start == 1) //התחלה - 1
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

        public static List<Route> CreateRoute(List<Nodes> ln)
        {
           

List<Route> rList = new List<Route>();
            using (var db = new EazyShopEntities())
            {
                ln = db.GetDbSet<Nodes>().ToList();



                
                foreach (Nodes node in ln)
                {
                    foreach (var otherNode in node.Nodes1)
                    {
                        
                        double x = Math.Sqrt(Math.Pow(Convert.ToDouble(node.Value_X - otherNode.Value_X), 2) + Math.Pow(Convert.ToDouble(node.Value_Y - otherNode.Value_Y), 2));
                        rList.Add(new Route(node, otherNode, x));


                    }
               
                }
            }
            return rList;
        }



    }
}
