using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace BL.Dijxtra
{

    public class product_node
    {
        public Products product { get; set; }
        public Nodes node { get; set; }

    }
    public class List_productNode
    {
        public List<product_node> list = new List<product_node>();


        public void Add(Products p, Nodes n)
        {
            list.Add(new product_node() { product = p, node = n });
        }

        public Products getProduct(Nodes n)
        {
            Products i = list.Find(x => x.node.Node_Kod == n.Node_Kod).product;
            return i;
        }

        public Nodes getNode(Products i)
        {
            Nodes code = list.Find(x => x.product.Product_Code == i.Product_Code).node;
            return code;
        }

    }

    public class Dijxtra
    {

        static DBConection db = new DBConection();

        public static List<product_node> CreateShortestRouteOnStore()
        {
            //לא לשכוח לשנות
            List<DTOProduct> pl = DTOProduct.CreatDtoList(db.GetDbSet<Products>().Where(p => p.Product_Code == 8 || p.Product_Code == 77).ToList());
            //  באתחול לבנות רשימת צמתים של כל הסופר בכללי 
            List_productNode superNODES = new List_productNode();
            //רשימת צמתים מאותחלת 
            List<DTONodes> dtoNodesList = new List<DTONodes>();
            using (var db = new EazyShopEntities())
            {

                List<Products> productsList = db.GetDbSet<Products>().ToList();
                productsList = productsList.Where(p => pl.FirstOrDefault(p1 => p1.Product_code == p.Product_Code) != null).ToList();

                //רשימת המצתים  מאותחלת ללרשימה שהלקוח מעונין לעבור בה של המסלול שצריך להחזיר  1 
                superNODES = ConvertProductToNodes(productsList);

                List<Nodes> nodes = superNODES.list.Select(x => x.node).ToList();
                //2 רשימת קשתות אתחול 
                List<Route> routesList = new List<Route>();
                routesList = CreateRouteForSuper();
                List<Nodes> superNodes = db.GetDbSet<Nodes>().ToList();
                //חישוב מטריצת מרחקים
                Cell[,] matrix = DijkstraFunction.ComputeDikjstra(superNodes, routesList);
             

            }
            return null;
        }


        public static List_productNode ConvertProductToNodes(List<Products> lp)
        {
            List<Products> productsList = new List<Products>();
            List<Nodes> nodesList = new List<Nodes>();
            List_productNode List_productNode = new List_productNode();

            foreach (var p in lp)
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
                List_productNode.Add(p, node);
            }

            return List_productNode;
        }

        public static List<Route> CreateRouteForSuper()
        {


            List<Route> rList = new List<Route>();

            using (var db = new EazyShopEntities())
            {
                List<Nodes> ln = db.GetDbSet<Nodes>().ToList();
                //ln = db.GetDbSet<Nodes>().ToList();
                foreach (Nodes node in ln)
                {

                    foreach (var otherNode in node.Nodes1)
                    {
                        if (node == otherNode)
                            continue;
                        double x = Math.Sqrt(Math.Pow(Convert.ToDouble(node.Value_X - otherNode.Value_X), 2) +
                            Math.Pow(Convert.ToDouble(node.Value_Y - otherNode.Value_Y), 2));
                        rList.Add(new Route(node, otherNode, x));


                    }

                }
            }
            return rList;
        }


    }
}



