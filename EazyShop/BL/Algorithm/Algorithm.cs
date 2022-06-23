using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Algorithm
{
    public class Algorithm
    {

        DBConection db = new DBConection();

        //גרף ורשימת צמתים למסלול
        Graph super = new Graph();
        List<Node> passNodes = new List<Node>();
        List<Node> finalRealPath = new List<Node>();

        public List<Node> FindPath(List<DTOProduct> products)
        {


            InitGraph();
            InitPassNodes(products);

            Node start = null;
            Node end = null;
            PrioQueue queue = null;
            List<int> unvisited = null;
            double minDistance = 0;
            List<Node> minDistancePath = null;

            start = passNodes[0];
            while (passNodes.Count != 1) //לולאה המגדירה צומת התחלה בגרף
            {
             
                   minDistance = double.MaxValue;
                foreach (Node n in passNodes)                      //נרצה להגיע לאחד מהצמתים האחרים שרוצים לעבור בהם
                {
                    if (n.Id != start.Id)
                    {
                        PrepareDijxtra(ref start, ref queue, ref unvisited);
                        ;
                        end = n;

                        double distance = MakeDijxtra(queue, unvisited, start, end); //נבדוק האם הצומת הנוכחית היא הכי קרובה לצומת ההתחלה
                        if (minDistance > distance)
                        {
                            minDistance = distance;
                            minDistancePath = new List<Node>();
                            Node goBackNode = super.Nodes[end.Id];
                            while (goBackNode != null)
                            {
                                minDistancePath.Add(goBackNode);
                                goBackNode = super.Nodes[goBackNode.Id].PreviousNode;
                            }
                            minDistancePath.Reverse();
                        }

                    }
                }
                Node removedNode = passNodes.FirstOrDefault(n => n.Id == start.Id);
                passNodes.Remove(removedNode); //מקטינה את הגרף
                start = minDistancePath[minDistancePath.Count - 1];
                foreach (var n in minDistancePath)
                {
                    finalRealPath.Add(n);
                }
            }
            //פה צריך לעדכן את המשתנה "סוף" שיהיה הסוף של המסלול שנבחר
            return finalRealPath;





        }

        public void InitGraph()
        {
            List<Nodes> nodes;
            List<Route> routes;
            nodes = db.GetDbSet<Nodes>().ToList();
            routes = CreateRouteForNodes();
            foreach (var n in nodes)
            {
                Node dictNode = new Node(n.Node_Kod, (int)n.Value_X, (int)n.Value_Y);
                super.Nodes.Add(n.Node_Kod, dictNode);
            }
            super.Routes = routes;
        }

        public void InitPassNodes(List<DTOProduct> userProduct)
        {
            List<Products> productsList = new List<Products>();
            using (EazyShopEntities db = new EazyShopEntities())
            {
                foreach (var up in userProduct)
                {
                    Products p = db.GetDbSet<Products>().FirstOrDefault(p1 => p1.Product_Code == up.Product_code);
                    productsList.Add(p);
                }

                List<Node> nodesList = new List<Node>();

                Nodes start = db.GetDbSet<Nodes>().FirstOrDefault();

                nodesList.Add(new Node(start.Node_Kod, (int)start.Value_X, (int)start.Value_Y));

                foreach (var p in productsList)
                {
                    Nodes node;
                    Node dictNode;
                    if (p.Columns.Start == 1)
                    {
                        node = p.Columns.Transition.Nodes;
                        dictNode = new Node(node.Node_Kod, (int)node.Value_X, (int)node.Value_Y);
                    }
                    else
                    {
                        node = p.Columns.Transition.Nodes1;
                        dictNode = new Node(node.Node_Kod, (int)node.Value_X, (int)node.Value_Y);
                    }
                    if (nodesList.Where(nl=>nl.Id == dictNode.Id ).ToList().Count == 0)
                    {
                        nodesList.Add(dictNode);
                    }
                }
                passNodes = nodesList;
            }

        }

        public List<Route> CreateRouteForNodes()
        {
            List<Route> rList = new List<Route>();

            using (var db = new EazyShopEntities())
            {
                List<Nodes> ln = db.GetDbSet<Nodes>().ToList();
                foreach (Nodes node in ln)
                {
                    List<Nodes> neighborsNodes = node.Nodes1.ToList();

                    foreach (var otherNode in neighborsNodes)
                    {
                        if (node == otherNode)
                            continue;
                        double x = Math.Sqrt(Math.Pow(Convert.ToDouble(node.Value_X - otherNode.Value_X), 2) +
                            Math.Pow(Convert.ToDouble(node.Value_Y - otherNode.Value_Y), 2));
                        rList.Add(new Route(node.Node_Kod, otherNode.Node_Kod, x));
                        rList.Add(new Route(otherNode.Node_Kod, node.Node_Kod, x));

                    }

                }
            }
            return rList;
        }

        public void PrepareDijxtra(ref Node start, ref PrioQueue queue, ref List<int> unvisited)
        {
            ClearGraphValues();
            super.Nodes[start.Id].Value = 0;
            start.Value = 0;
            queue = new PrioQueue();
            queue.AddNodeWithPriority(start);
            unvisited = new List<int>();
            foreach (var n in super.Nodes.Values)
            {
                unvisited.Add(n.Id);
            }


        }
        public double MakeDijxtra(PrioQueue queue, List<int> unvisited, Node start, Node end)
        {
            var c = new Node(start.Id, start.X,start.Y);
            c.Value = start.Value;
            while (super.Nodes[end.Id].Value == double.MaxValue && queue.First != null)
            {
                List<Route> routes = super.Routes.Where(r => r.SourceId == c.Id).ToList();

                foreach (var r in routes)
                {
                    if (!unvisited.Contains(r.DestinationId))
                    {
                        continue;
                    }
                    double calculatedDistance = c.Value + r.Distance;
                    if (calculatedDistance < super.Nodes[r.DestinationId].Value)
                    {
                        super.Nodes[r.DestinationId].Value = calculatedDistance;
                        super.Nodes[r.DestinationId].PreviousNode = c;
                    }
                    if (!queue.CheckNodeExists(super.Nodes[r.DestinationId]))
                    {
                        queue.AddNodeWithPriority(super.Nodes[r.DestinationId]);
                    }
                }
                unvisited.Remove(c.Id);
                queue.RemoveFirst();
                if (queue.First == null)
                    return double.MaxValue;
                else
                    c =  queue.First.Value;
            }



            return super.Nodes[end.Id].Value;
        }



        public void ClearGraphValues()
        {
            foreach (var k in super.Nodes.Keys)
            {
                super.Nodes[k].Value = double.MaxValue;
                super.Nodes[k].PreviousNode = null;
            }
        }







    }
    public class Graph
    {
        public Dictionary<int, Node> Nodes { get; set; }
        public List<Route> Routes { get; set; }
        public Graph()
        {
            Nodes = new Dictionary<int, Node>();
            Routes = new List<Route>();
        }
    }
    public class Node
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public double Value { get; set; }
        public Node PreviousNode { get; set; }
        public Node(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
            Value = double.MaxValue;
            PreviousNode = null;
        }

    }
    public class Route
    {
        public int SourceId { get; set; }
        public int DestinationId { get; set; }

        public double Distance { get; set; }
        public Route(int s, int d, double di)
        {
            SourceId = s;
            DestinationId = d;
            Distance = di;
        }
    }

}
