//using DAL;
//using DTO;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BL;
//using BL.BSD;

//namespace BL.BSD
//{
//    //טיפול בחישוב המסלול הקצר ביותר לביצוע הזמנות
//    // בכל שלב נלקחות 3 ההזמנות בעלות ערך ההתאמה הגבוהה ביותר
//    class PassNodes
//    {
//        public class Product_node
//        {

//            public Nodes node { get; set; }
//            public List<Products> productList { get; set; }

//        }
//        public class List_productNode
//        {
//            public List<Product_node> list = new List<Product_node>();


//            public void Add(List<Products> p, Nodes n)
//            {
//                list.Add(new Product_node() { productList = p, node = n });
//            }

//            public List<Products> getProducts(Nodes n)
//            {
//                List<Products> l = list.Find(x => x.node.Node_Kod == n.Node_Kod).productList;
//                return l;
//            }

//            public Nodes getNode(Products i)
//            {
//                Nodes code = list.Find(x => x.productList.Contains(i)).node;
//                return code;
//            }



//        }

      
//        #region טיוטה
//        //public static List<Products> GetProductsFromDB()
//        //{
//        //    List<Products> dbProductsList = new List<Products>();

//        //    using (EazyShopEntities db = new EazyShopEntities())
//        //    {
//        //        //המרה לרשימת מוצרים מהדאטה בייס
//        //        foreach (var p in lp)
//        //        {
//        //            Products dbProduct = db.GetDbSet<Products>().FirstOrDefault(p1 => p1.Product_Code == p.Product_code);
//        //            dbProductsList.Add(dbProduct);
//        //        }
//        //    }

//        //    return dbProductsList;
//        //}
//        //סינון לפי  סוג צומת
//        //var startNodesProducts = dbProductsList.Where(p => p.Columns.Start == 1);

//        //var endNodeProducts = dbProductsList.Where(p => p.Columns.Start == 0);

//        ////קיבוץ רשימת מצרים לפי צומת
//        //var groupedStarts = startNodesProducts.GroupBy(p => p.Columns.Transition.Start_Kod).ToList();
//        //var groupedEnds = startNodesProducts.GroupBy(p => p.Columns.Transition.End_Kod).ToList();


//        //ממזג לרשימה המשוכללת

//        //List_productNode List_productNode = new List_productNode();

//        //foreach (var node in groupedStarts)
//        //{

//        //}
//        //foreach (var node in groupedEnds)
//        //{

//        //}


//        //return List_productNode;
//        //}
//        //}

//        #endregion
//        static DBConection db = new DBConection();
//        Nodes _startNode = db.GetDbSet<Nodes>().FirstOrDefault();
//        public static Dictionary<int, List<Nodes>> _dicNodesToPrint;

// public void PassingNodes()
// {

//            _dicNodesToPrint = new Dictionary<int, List<Nodes>>();
//            //בכל סבב  נתוני הקודקודים במפה מקבלים ערכים שונים
//            // לכן יש צורך לשמר את נתוני המפה המקורית כדי להתחיל כל סבב חדש עם נתונים התחלתיים
//            List<Nodes> _orginalListNodes = CloneListNode(groupedStarts, _startNode);
//            List<int> _listNodeVisited = new List<int>();

//            //שליפת הזמנות בעלות ערך ההתאמה של מחלקות הגבוהה ביותר
//            List<Products> _itemListToSupply = CreateThreeOrdersCombination.GetItemsOfThreeBestOrders();

//            List<Nodes> _listNodeToSupply = new List<Nodes>();
//            //רשימת הקודקודים שבהן ישנם מוצרים להספקה
//            _listNodeToSupply = (from x in db.listNodes
//                                 from y in db._listLocation
//                                 from z in _itemListToSupply

//                                 where x.IDVertexes == y.IDVertexes &&
//                                       y.IDLocation == z.IDLocation.IDVertexes
//                                 select x).Distinct().ToList();

//            for (int i = 0; i < _listNodeToSupply.Count(); i++)
//            {
//                ClearNode(_startNode);
//                //חישוב המרחקים בין קודקוד התחלה לכל הקודקודים במפה
//                CalcDIstance(_startNode);

//                //מציאת קודקוד התחלה הבאה לפי ערכו הנמוך ביותר
//                //מתוך רשימת הקודקודים שיש בהן מוצרים להספקה
//                _startNode = (from x in (db.listNodes.Where(x => !_listNodeVisited.Contains(x.IDVertexes)).OrderByDescending(x => x.nodeValue))
//                              from y in (_listNodeToSupply)
//                              where x.IDVertexes == y.IDVertexes
//                              select x).Last();
//                select new Nodes()
//                {
//                    IDVertexes = x.IDVertexes,
//                    vertexColumn = x.vertexColumn,
//                    nodeIsViseted = x.nodeIsViseted,
//                    nodeName = x.nodeName,
//                    nodePreviousNode = x.nodePreviousNode,
//                    vertexRow = x.vertexRow,
//                    nodeValue = x.nodeValue,
//                }).Last();
//            _listNodeVisited.Add(_startNode.IDVertexes);
//            //רשימה השומרת לכול קודקוד יעד את המסלול להגעה אליו
//                _dicNodesToPrint.Add(_startNode.IDVertexes, db.listNodes);

//            db.listNodes = CloneListNode(_orginalListNodes, _startNode);
//            foreach (passes _pass in db.listPass)
//            {
//                _pass.IDVertex1 = db.listNodes.Find(x => x.IDVertexes == _pass.IDVertex1.IDVertexes);
//                _pass.IDVertex2 = db.listNodes.Find(x => x.IDVertexes == _pass.IDVertex2.IDVertexes);
//            }
//        }

//    }

//    //חישוב המרחקים הקצרים ביותר בין קודקוד התחלה לכל הקודקודים במפה
//        public void CalcDIstance(Nodes startNode)
//    {
//        double _distance = 0;
//        //Nodes _startNode = startNode;
//        List<Route> _ListPass = new List<Route>();
//        //סריקת כל המפה, כי חישוב הדרך הקצרה יכול לעבור גם בין קודקודים שאין בהן מוצרים להספקה
//            while (db.listNodes.Where(x => !x.nodeIsViseted).Count() > 0)
//        {
//            //מעבר על הקשתות שיוצאים מקודקוד מסויים
//                _ListPass = db.listPass.FindAll(r => !r.IDVertex2.nodeIsViseted && r.IDVertex1.IDVertexes == _startNode.IDVertexes).OrderBy(x => x.passDistance).ToList();

//            foreach (Route _Pass in _ListPass)
//            {
//                _distance = startNode.nodeValue + CreateRouteForSuper(startNode, _Pass.IDVertex2);
//                if (_distance < _Pass.IDVertex2.nodeValue)
//                {
//                    _Pass.value = _distance;
//                    //ההצבעה על הקודם
//                        _Pass.source.nodePreviousNode = _Pass.destination;
//                }
//            }
//            startNode.nodeIsViseted = true;

//            //קודקוד ההתחלה משתנה - דילוג לקודקוד בעל הערך הנמוך ביותר
//            startNode = db.listNodes.Where(x => !x.nodeIsViseted).OrderBy(x => x.nodeValue).FirstOrDefault();
//        }
//    }

//    //חישוב קשת
//        double CalcPass(Nodes fromNode, Nodes toNode)
//    {
//        return (db.listPass.Find(x => x.IDVertex1.IDVertexes == fromNode.IDVertexes && x.IDVertex2.IDVertexes == toNode.IDVertexes)).passDistance;
//    }


//    private List<Nodes> CloneListNode(List<Nodes> _fromlist, Nodes startNode)
//    {
//        List<Nodes> _listNodes = new List<Nodes>();

//        foreach (Nodes _node in _fromlist)
//        {
//            _listNodes.Add(new Nodes()
//            {
//                vertexColumn = _node.vertexColumn,
//                IDVertexes = _node.IDVertexes,
//                nodeIsViseted = _node.nodeIsViseted,
//                nodeName = _node.nodeName,
//                nodePreviousNode = _node.nodePreviousNode,
//                vertexRow = _node.vertexRow,
//                nodeValue = _node.IDVertexes == startNode.IDVertexes ? 0 : int.MaxValue
//            });
//        }
//        return _listNodes;
//    }

//    //אתחול צומת-מחיקת הערכים-ניקוי חלקי של הצומת בעבור המשך חישוב המסלול
//        private void ClearNode(Nodes _nodeToClear)
//    {
//        _nodeToClear.nodeIsViseted = false;
//        _nodeToClear.nodePreviousNode = null;
//        _nodeToClear.nodeValue = 0;

//    }

//    private void PrintWalkingPath()
//    {
//        List<Nodes> _listNodes = new List<Nodes>();
//        Nodes _startNode = new Nodes();
//        foreach (int _startNodeindex in _dicNodesToPrint.Keys)
//        {
//            _dicNodesToPrint.TryGetValue(_startNodeindex, out _listNodes);

//            _startNode = _listNodes.Where(x => x.IDVertexes == _startNodeindex).LastOrDefault();
//            printPath(_startNode);
//        }
//    }
//    void printPath(Nodes _printNode)
//    {

//        if (_printNode != null && _printNode.nodePreviousNode != null)
//            printPath(_printNode.nodePreviousNode);
//        System.Diagnostics.Debug.WriteLine("Node {0}", _printNode.IDVertexes);
//    }



//    //חישוב קשתות מצומת לצמתים שכנים
// public static List<Route> CreateRouteForSuper(Nodes startNode, Route.IDVertex2)
// {

//        List<Route> rList = new List<Route>();

//        using (var db = new EazyShopEntities())
//        {
//            List<Nodes> ln = db.GetDbSet<Nodes>().ToList();
//            //ln = db.GetDbSet<Nodes>().ToList();
//            foreach (Nodes node in ln)
//            {

//                foreach (var otherNode in node.Nodes1)
//                {
//                    if (node == otherNode)
//                        continue;
//                    double x = Math.Sqrt(Math.Pow(Convert.ToDouble(node.Value_X - otherNode.Value_X), 2) +
//                        Math.Pow(Convert.ToDouble(node.Value_Y - otherNode.Value_Y), 2));
//                    rList.Add(new Route(node, otherNode, x));


//                }

//            }
//        }
//        return rList;
//    }


//    //public Nodes GetNeighboring(Nodes n)
//    //{
//    //    return (Nodes)n.Nodes1;
//    //}

//}






////public class Dijxtra
////{

////    static DBConection db = new DBConection();


////    public static void ConvertProductsToNodes(List<DTOProduct> lp)
////    {
////        using (EazyShopEntities db = new EazyShopEntities())
////        {
////            //המרה לרשימת מוצרים מהדאטה בייס
////            List<Products> dbProductsList = new List<Products>();
////            foreach (var p in lp)
////            {
////                Products dbProduct = db.GetDbSet<Products>().FirstOrDefault(p1 => p1.Product_Code == p.Product_code);
////                dbProductsList.Add(dbProduct);
////            }
////            //סינון לפי  סוג צומת
////            var startNodesProducts = dbProductsList.Where(p => p.Columns.Start == 1);

////            var endNodeProducts = dbProductsList.Where(p => p.Columns.Start == 0);

////            //קיבוץ רשימת מצרים לפי צומת
////            var groupedStarts = startNodesProducts.GroupBy(p => p.Columns.Transition.Start_Kod);
////            var groupedEnds = startNodesProducts.GroupBy(p => p.Columns.Transition.End_Kod);


////            //ממזג לרשימה המשוכללת

////            List_productNode List_productNode = new List_productNode();

////            foreach (var node in groupedStarts)
////            {

////            }
////            foreach (var node in groupedEnds)
////            {

////            }


////            //return List_productNode;
////        }
////    }






