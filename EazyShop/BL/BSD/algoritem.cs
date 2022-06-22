//using DAL;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.SqlClient;
//using System.Configuration;
//using System.Data;

//namespace BL.BSD
//{
//    class algoritem
//    {

//        static DBConection db = new DBConection();


//        //טיפול בחישוב המסלול הקצר ביותר לביצוע הזמנות
//        // בכל שלב נלקחות 3 ההזמנות בעלות ערך ההתאמה הגבוהה ביותר
//        Nodes _startNode = db.GetDbSet<Nodes>().FirstOrDefault();
//        public static Dictionary<int, List<Nodes>> _dicNodesToPrint;

//        public void PassingNodes()
//        {

//            _dicNodesToPrint = new Dictionary<int, List<Nodes>>();
//            //בכל סבב  נתוני הקודקודים במפה מקבלים ערכים שונים
//            // לכן יש צורך לשמר את נתוני המפה המקורית כדי להתחיל כל סבב חדש עם נתונים התחלתיים
//            List<Location> _orginalListNodes = CloneListNode(db.GetDbSet<Nodes>().ToList(), _startNode);
//            List<int> _listNodeVisited = new List<int>();

//            //שליפת הזמנות בעלות ערך ההתאמה של מחלקות הגבוהה ביותר
//            List<Products> _itemListToSupply = CreateThreeOrdersCombination.GetItemsOfThreeBestOrders();

//            List<Location> _listNodeToSupply = new List<Location>();
//            //רשימת הקודקודים שבהן ישנם מוצרים להספקה
//            _listNodeToSupply = (from x in db.listNodes
//                                 from y in db._listLocation
//                                 from z in _itemListToSupply
//                                 where x.IDNodes == y.IDNodes &&
//                                       y.IDLocation == z.IDLocation.IDNodes
//                                 select x).Distinct().ToList();

//            for (int i = 0; i < _listNodeToSupply.Count(); i++)
//            {
//                ClearNode(_startNode);
//                //חישוב המרחקים בין קודקוד התחלה לכל הקודקודים במפה
//                CalcDIstance(_startNode);

//                //מציאת קודקוד התחלה הבאה לפי ערכו הנמוך ביותר
//                //מתוך רשימת הקודקודים שיש בהן מוצרים להספקה
//                _startNode = (from x in (db.listNodes.Where(x => !_listNodeVisited.Contains(x.IDNodes)).OrderByDescending(x => x.nodeValue))
//                              from y in (_listNodeToSupply)
//                              where x.IDLocation == y.IDNodes
//                              select x).Last();
//                select new Nodes()

//                {

//                    IDNodes = x.IDNodes,
//                    vertexColumn = x.vertexColumn,
//                    nodeIsViseted = x.nodeIsViseted,
//                    nodeName = x.nodeName,
//                    nodePreviousNode = x.nodePreviousNode,
//                    vertexRow = x.vertexRow,
//                    nodeValue = x.nodeValue,
//                }).Last();
//            _listNodeVisited.Add(_startNode.IDNodes);
//            //רשימה השומרת לכול קודקוד יעד את המסלול להגעה אליו
//            _dicNodesToPrint.Add(_startNode.IDNodes, db.listNodes);

//            db.listNodes = CloneListNode(_orginalListNodes, _startNode);
//            foreach (passes _pass in db.listPass)
//            {
//                _pass.IDVertex1 = db.listNodes.Find(x => x.IDNodes == _pass.IDVertex1.IDNodes);
//                _pass.IDVertex2 = db.listNodes.Find(x => x.IDNodes == _pass.IDVertex2.IDNodes);
//            }
//        }

//    }

//    //חישוב המרחקים הקצרים ביותר בין קודקוד התחלה לכל הקודקודים במפה
//    public void CalcDIstance(Nodes startNode)
//    {
//        double _distance = 0;
//        Nodes _startNode = startNode;
//        List<Vertax> ListPass = new List<passes>();
//        //סריקת כל המפה, כי חישוב הדרך הקצרה יכול לעבור גם בין קודקודים שאין בהן מוצרים להספקה
//        while (db.listNodes.Where(x => !x.nodeIsViseted).Count() > 0)
//        {
//            //מעבר על הקשתות שיוצאים מקודקוד מסויים
//            _ListPass = db.listPass.FindAll(r => !r.IDVertex2.nodeIsViseted && r.IDVertex1.IDNodes == _startNode.IDNodes).OrderBy(x => x.passDistance).ToList();

//            foreach (passes _Pass in _ListPass)
//            {
//                _distance = _startNode.nodeValue + CalcPass(_startNode, _Pass.IDVertex2);
//                if (_distance < _Pass.IDVertex2.nodeValue)
//                {
//                    _Pass.IDVertex2.nodeValue = _distance;
//                    //ההצבעה על הקודם
//                    _Pass.IDVertex2.nodePreviousNode = _Pass.IDVertex1;
//                }
//            }
//            _startNode.nodeIsViseted = true;

//            //קודקוד ההתחלה משתנה - דילוג לקודקוד בעל הערך הנמוך ביותר
//            _startNode = db.listNodes.Where(x => !x.nodeIsViseted).OrderBy(x => x.nodeValue).FirstOrDefault();
//        }
//    }

//    //חישוב קשת
//    double CalcPass(Nodes fromNode, Nodes toNode)
//    {
//        return (db.listPass.Find(x => x.IDVertex1.IDNodes == fromNode.IDNodes && x.IDVertex2.IDNodes == toNode.IDNodes)).passDistance;
//    }

//    //מקבלת רשימה וצומת התחלה 
//    private List<Nodes> CloneListNode(List<Nodes> _fromlist, Nodes startNode)
//    {
//        List<Nodes> _listNodes = new List<Nodes>();

//        foreach (Nodes _node in _fromlist)
//        {
//            //בניית הצומת 

//            _listNodes.Add(new Nodes()
//            {
//                PreviousNode = _node.PreviousNode,
//                Node_Kod = _node.Node_Kod,
//                Value_X = _node.Value_X,
//                Value_Y = _node.Value_Y,
//                Name_Node = _node.Name_Node,

//            });
//        }
//        //החזרת הרשימה 
//        return _listNodes;
//    }

//    //אתחול צומת-מחיקת הערכים-ניקוי חלקי של הצומת בעבור המשך חישוב המסלול
//    private void ClearNode(Nodes _nodeToClear)
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

//            _startNode = _listNodes.Where(x => x.IDNodes == _startNodeindex).LastOrDefault();
//            printPath(_startNode);
//        }
//    }
//    void printPath(Nodes _printNode)
//    {

//        if (_printNode != null && _printNode.nodePreviousNode != null)
//            printPath(_printNode.nodePreviousNode);
//        System.Diagnostics.Debug.WriteLine("Node {0}", _printNode.IDNodes);
//    }
//}



////רשימה של כל הצמתים הראשונים -כל הגרף כל הסופר-עובד
//List<Nodes> AllNodes = db.GetDbSet<Nodes>();


////עובד-רשימה של כל הקשתות בכל הסופר
//List<BL.BSD.Route> AllRoute = CreateRouteForSuper();


////מקבלים את הרשימה של הצצמתים שנבחרו
//List<Nodes> choce = new List<Nodes>();






//dikjstra(AllRoute, AllNodes);









////יוצר רשימת קשתות בכל הסופר
//public static List<BL.BSD.Route> CreateRouteForSuper()
//{


//    List<Route> rList = new List<Route>();

//    using (var db = new EazyShopEntities())
//    {
//        List<Nodes> ln = db.GetDbSet<Nodes>().ToList();
//        ln = db.GetDbSet<Nodes>().ToList();
//        foreach (Nodes node in ln)
//        {

//            foreach (var otherNode in node.Nodes1)
//            {
//                if (node == otherNode)
//                    continue;
//                double x = Math.Sqrt(Math.Pow(Convert.ToDouble(node.Value_X - otherNode.Value_X), 2) +
//                    Math.Pow(Convert.ToDouble(node.Value_Y - otherNode.Value_Y), 2));
//                rList.Add(new Route(node, otherNode, x));


//            }

//        }
//    }
//    return rList;
//}

////2 להפעיל את הדייאקסטראה על הכל הסופר



//public void dikjstra(List<BL.BSD.Route> AllRoute, List<Nodes> AllNodes)
//{

//    for (int i = 0; i < AllNodes.Count(); i++)
//    {
//        //לכל צומת מוצאים את כל הקשתות שלו ועוברים עלייהם
//        List<Route> r = AllRoute.Where(s => s.source.Node_Kod == AllNodes[i].Node_Kod).ToList();
//        //מגדירים מרחק הכי גדול שיש
//        double min = int.MaxValue;
//        for (int j = 0; j < r.Count(); j++)
//        {
//            if (r[j].value < min)
//            {
//                min = r[j].value;
//            }


//        }
//    }

//    {
//        ///פה אני צריכה לעשות נקודת עצירה 
//        //תנאי עצירה בחיפוש מסלול קצר בין כל הנקודות בגרף
//        if (queue.Count == 0)
//        {
//            return;
//        }
//        //תנאי עצירה בחיפוש מסלול קצר בין מקור ליעד
//        if (lastNode != null && destinationNode != null && lastNode.Store.NameStor.Equals(destinationNode.Store.NameStor))
//        {
//            return;
//        }
//        //רשימת קשתות של צומת 
//        List<Route> neighborRoutes = routes.Where(s => s.From.Equals(queue.First.Value)).ToList();
//        foreach (var r in neighborRoutes)
//        {
//            //אם קוד היעד לא נמצא ברשימה שצריך לבקר בה סימן שביקרו בו - נדלג עליו
//            if (!unvisited.Contains(r.To))
//            {
//                continue;
//            }
//            //מעדכנת מה המרחק עד לצומת הנוכחית - מה היה המרחק עד הגעה לצומת הנוחכית 
//            double travelDistance = nodes[queue.First.Value.Store.NameStor].Value + r.Distance;
//            //בדיקה האם מה שחישבתי עכשיו יותר קצר ממה שקיים בצומת היעד עד עכשיו 
//            if (travelDistance < nodes[r.To.Store.NameStor].Value)
//            {
//                //אם כן -תעדכן 
//                nodes[r.To.Store.NameStor].Value = travelDistance;
//                //הקודם 
//                nodes[r.To.Store.NameStor].PreviousNode = r.From;
//                //  travelDistance צריך פה גם לעדכן שוב את ה
//            }
//            if (!queue.HasLetter(r.To))
//            {
//                queue.AddNodeWithPriority(r.To);
//            }
//        }
//        unvisited.Remove(queue.First.Value);
//        lastNode = nodes[queue.First.Value.Store.NameStor];
//        queue.RemoveFirst();
//        CheckNode(routes, nodes, queue, unvisited, destinationNode, ref lastNode, ref dist);
//        return;
//    }
//}




//}








