using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace BL.BSD
{

    public class Product_node
    {

        public Nodes node { get; set; }
        public List<Products> productList { get; set; }

    }
    public class List_productNode
    {
        public List<Product_node> list = new List<Product_node>();


        public void Add(List<Products> p, Nodes n)
        {
            list.Add(new Product_node() { productList = p, node = n });
        }

        public List<Products> getProducts(Nodes n)
        {
            List<Products> l = list.Find(x => x.node.Node_Kod == n.Node_Kod).productList;
            return l;
        }

        public Nodes getNode(Products i)
        {
            Nodes code = list.Find(x => x.productList.Contains(i)).node;
            return code;
        }

    }

    public class Dijxtra
    {

        static DBConection db = new DBConection();


        public static void ConvertProductsToNodes(List<DTOProduct> lp)
        {
            using (EazyShopEntities db = new EazyShopEntities())
            {
                //המרה לרשימת מוצרים מהדאטה בייס
                List<Products> dbProductsList = new List<Products>();
                foreach (var p in lp)
                {
                    Products dbProduct = db.GetDbSet<Products>().FirstOrDefault(p1 => p1.Product_Code == p.Product_code);
                    dbProductsList.Add(dbProduct);
                }
                //סינון לפי  סוג צומת
                var startNodesProducts = dbProductsList.Where(p => p.Columns.Start == 1);

                var endNodeProducts = dbProductsList.Where(p => p.Columns.Start == 0);

                //קיבוץ רשימת מצרים לפי צומת
                var groupedStarts = startNodesProducts.GroupBy(p => p.Columns.Transition.Start_Kod);
                var groupedEnds = startNodesProducts.GroupBy(p => p.Columns.Transition.End_Kod);


                //ממזג לרשימה המשוכללת

                List_productNode List_productNode = new List_productNode();

                foreach (var node in groupedStarts)
                {

                }
                foreach (var node in groupedEnds)
                {

                }


                //return List_productNode;
            }
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



