//using DAL;
//using DTO;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BL.Dijxtra
//{
//    public class Algorithm
//    {
//        static DBConection db = new DBConection();

//        public static List<object> CreateShortestRouteOnStore(List<DTOProduct> pl)
//        {
//            List<DTONodes> dtoNodesList = new List<DTONodes>();
//            List<Products> productsList = db.GetDbSet<Products>().Where(p => pl.FirstOrDefault(p1 => p1.Product_code == p.Product_Code) != null).ToList();


//            List<Nodes> nodesList = ConvertProductToNodes(productsList);



//            return null;
//        }


//        public static List<Nodes> ConvertProductToNodes(List<Products> lp)
//        {
//            List<Products> productsList = new List<Products>();
//            List<Nodes> nodesList = new List<Nodes>();

//            foreach (var p in productsList)
//            {
//                Nodes node;
//                if (p.Columns.Start == 1) //התחלה - 1
//                {
//                    node = p.Columns.Transition.Nodes;
//                }
//                else
//                {
//                    node = p.Columns.Transition.Nodes1;
//                }
//                nodesList.Add(node);
//            }

//            return nodesList;
//        }

//        public static List<Route> CreateRoute(List<Nodes> ln)
//        {


//List<Route> rList = new List<Route>();
//            using (var db = new EazyShopEntities())
//            {
//                ln = db.GetDbSet<Nodes>().ToList();




//                foreach (Nodes node in ln)
//                {
//                    foreach (var otherNode in node.Nodes1)
//                    {

//                        double x = Math.Sqrt(Math.Pow(Convert.ToDouble(node.Value_X - otherNode.Value_X), 2) + Math.Pow(Convert.ToDouble(node.Value_Y - otherNode.Value_Y), 2));
//                        rList.Add(new Route(node, otherNode, x));


//                    }

//                }
//            }
//            return rList;
//        }



//    }
//}
//using BL.Dijxtra;
//using DAL;
//using DTO;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BL.BL
//{
//    public class Dijkstra
//    {
//        public Dijkstra(List<DTONodes> Node)
//        {
//            mallGraphNodes = createMallNodes();
//            mallGraphRoutes = createMallRoutes(graphFilePath);
//            createSelectedStoresGraph(Node);
//            createShortestPathForSelectedStores();

//        }
//        //הדאטה ביס של כל המערכת 
//        static DBConection db = new DBConection();
//        //הניתוב של הגרף
//        static string graphFilePath = @"C:\Users\student\Desktop\liel\צד שרת\routes.txt";// @"..\..\BL\Dijkstra\routes.txt";
//        //אתחול רשימת הקשתות של הקומהה הראשונה בקניון 
//        static List<Route> mallGraphRoutes = null;
//        //אתחול המילון שמורכב משם צומת וצומת
//        static Dictionary<string, Nodes> mallGraphNodes = new Dictionary<string, Nodes>();
//        // אתחול רשימת הצמים בגרף החדש שניצור יהנו המסלול 
//        static List<Route> selectedStoresGraphRoutes = new List<Route>();
//        //אתחול המילון הצמתים של הגרף החדש
//        static Dictionary<string, Nodes> selectedStoresGraphNodes = new Dictionary<string, Nodes>();
//        //מקבלת רשימה של חניות למעבר ומחזירה את הרשימה הטובה =היעילה ביותר 
//        public static List<DTONodes> MapSelectedStores(List<DTONodes> Node)
//        {
//            //יצירת גרף של כל הקניון - קריאת הקשתות מקובץ  

//            mallGraphRoutes = createMallRoutes(graphFilePath);
//            //יצירת הצמתים שנמצאים בכל הקניון
//            mallGraphNodes = createMallNodes();
//            //יצירת גרף חדש של הקשתות בין החנויות הנבחרות  -  הפעלת הדיאקסטרה לכל חנות ברשימה ( שאר החנויות כיעד)

//            //יצית הגרף החדש - המסלול הקצר 
//            createSelectedStoresGraph(stores);
//            //הפעלת הדיאקסטרה על הגרף החדש.


//            return null;
//        }

//        //המרחקים הקשתות יוצרת גרף של כל המרחקים בקניון
//        public static List<Route> createMallRoutes(string path)//
//        {
//            List<Route> routes = new List<Route>();//
//            using (var reader = new StreamReader(graphFilePath, Encoding.Default))
//            {
//                for (int i = 0, countWord = 0; !reader.EndOfStream; i++, countWord = 0)
//                {
//                    var line = reader.ReadLine();
//                    var values = line.Split(',');
//                    Stor s1 = db.GetDbSet<Stor>().FirstOrDefault(s => s.Locations.LocationCode == long.Parse(values[2]));
//                    Stor s2 = db.GetDbSet<Stor>().FirstOrDefault(s => s.Locations.LocationCode == long.Parse(values[1]));

//                    routes.Add(new Route(new Node(new DTOStor(s1)), new Node(new DTOStor(s2)), double.Parse(values[0])));
//                }
//            }
//            return routes;
//        }
//        //הצמתים יוצרת גרף של כל החנויות בקניון
//        public static Dictionary<string, Node> createMallNodes()
//        {
//            Dictionary<string, Node> nodes = new Dictionary<string, Node>();
//            List<Stor> stores = db.GetDbSet<Stor>();
//            foreach (var s in stores)
//            {
//                DTOStor dtos = new DTOStor(s);
//                nodes.Add(dtos.NameStor, new Node(dtos));
//            }
//            return nodes;
//        }
//        //יצירת הגרף החדש =המסלול 
//        public static void createSelectedStoresGraph(List<DTOStor> stores)
//        {

//            //לכל חנות ברשימה הנבחרת
//            for (int i = 0; i < stores.Count(); i++)
//            {   //מאיפה להגיע מאיזה מקור
//                DTOStor from = stores[i];
//                //מוסיפה אותו לרשימת הצמתים בגרף החדש
//                selectedStoresGraphNodes.Add(from.NameStor, new Node(from));
//                //ניצור קשתות לשאר החנויות ברשימה
//                for (int j = 0; j < stores.Count(); j++)
//                {
//                    //כדי למנוע כפילויות - נדלג על החנות הנוכחית
//                    if (i == j)
//                        continue;
//                    //לאיפה אני מגיעה
//                    DTOStor to = stores[j];
//                    //נגדיר חנות נוכחית בתור התחלה
//                    Node start = new Node(from);
//                    //נגדיר חנות אחרת ברשימה בתור יעד
//                    Node end = new Node(to);
//                    //ניצור קשת - אבל - נאתחל את המרחק ב-0 כי עדיין לא ברור מה המרחק הכי קצר - צריך חישוב
//                    Route newRoute = new Route(start, end, 0);

//                    //חישוב המרחק הקצר ע''י דייקסטרה
//                    //השמת ערך 0 על הנקודה שבה אנחנו מתחילים 
//                    mallGraphNodes[start.Store.NameStor].Value = 0;
//                    //בונה תור עדיפות למרחקים קצרים
//                    PrioQueue queue = new PrioQueue();
//                    //מוסיפה לתור את הצומת התחלה 
//                    queue.AddNodeWithPriority(mallGraphNodes[start.Store.NameStor]);
//                    //מגדירה רשימת צמתים שלא בקרתי בהם 
//                    List<Node> unvisited = new List<Node>();
//                    //מעבר בלולאה כל הצמתים בקומה  
//                    foreach (var n in mallGraphNodes.Values)
//                    {//מוסיפה לרשימה את כל החניות בקומה 
//                        unvisited.Add(n);
//                    }
//                    //מקבלת  את המרחק הקצר שחוזר  - פב מתחילה הריקורסיה של הדיאקסטרה
//                    double shortestDistance = CheckNode(mallGraphRoutes, mallGraphNodes, queue, unvisited, end);
//                    //אתחול משקל הקשת למרחק הקצר שחזר
//                    newRoute.Distance = shortestDistance;
//                    //הוספה לרשימת הקשתות של הגרף החדש  את הקשת שחשבנו
//                    selectedStoresGraphRoutes.Add(newRoute);

//                }
//            }

//        }
//        //מציאת

//        public static void createShortestPathForSelectedProducts()
//        {

//            DTONodes entrance = new DTONodes();
//            entrance.Name_Node = "כניסה";
//            //נגדיר כניסה בתור התחלה
//            Nodes start = new Nodes();
//            //אין יעד - רוצים לעבור בין כל החנויות שנבחרו
//            Nodes end = null;

//            //חישוב המרחק הקצר ע''י דייקסטרה
//            //השמת ערך 0 על הנקודה שבה אנחנו מתחילים 
//            mallGraphNodes[start.Name_Node].Value = 0;
//            //אתחול התור -שממין את המרחקים הקצרים ביותר 
//            Queue queue = new Queue();
//            //ההתחליתית מוסיפה לתור את הצומת 
//            queue.AddNodeWithPriority(selectedStoresGraphNodes[start.Name_Node]);
//            //רשימה של צמתים שלא ביקרנו בהם עדיין 
//            List<Nodes> unvisited = new List<Nodes>();
//            //מוסיפה לרשימה הזאת את כל הצמתים כי בנתיים אנו בהתחלה -לא ביקרנו בשום מקום 
//            foreach (var n in selectedStoresGraphNodes.Values)
//            {
//                //
//                unvisited.Add(n);
//            }

//            double shortestDistance = CheckNode(selectedStoresGraphRoutes, selectedStoresGraphNodes, queue, unvisited, end);
//        }


//        //מחזירה את המרחק הקצר ביותר
//        private static double CheckNode(List<Route> routes, Dictionary<string, Nodes> nodes, Queue queue, List<Nodes> unvisited, Nodes destinationNode)
//        {
//            //תנאי עצירה בחיפוש מסלול קצר בין כל הנקודות בגרף
//            if (queue.Count == 0)
//            {
//                return 0;
//            }
//            //תנאי עצירה בחיפוש מסלול קצר בין מקור ליעד
//            if (queue.First.Value == destinationNode)
//            {
//                return destinationNode.Node_Kod;
//            }
//            //רשימת קשתות של צומת 
//            List<Route> neighborRoutes = routes.Where(s => s.From == queue.First.Value).ToList();
//            foreach (var r in neighborRoutes)
//            {
//                //אם קוד היעד לא נמצא ברשימה שצריך לבקר בה סימן שביקרו בו - נדלג עליו
//                if (!unvisited.Contains(r.To))
//                {
//                    continue;
//                }
//                //מעדכנת מה המרחק עד לצומת הנוכחית - מה היה המרחק עד הגעה לצומת הנוחכית 
//                double travelDistance = nodes[queue.First.Value.Store.NameStor].Value + r.Distance;
//                //בדיקה האם מה שחישבתי עכשיו יותר קצר ממה שקיים בצומת היעד עד עכשיו 
//                if (travelDistance < nodes[r.To.Store.NameStor].Value)
//                {//אם כן -תעדכן 
//                    nodes[r.To.Store.NameStor].Value = travelDistance;
//                    nodes[r.To.Store.NameStor].PreviousNode = r.From;\\הקודם
//                }

//                if (!queue.HasLetter(r.To))
//                {
//                    queue.AddNodeWithPriority(r.To);
//                }

//            }
//            unvisited.Remove(queue.First.Value);
//            //
//            queue.RemoveFirst();
//            CheckNode(routes, nodes, queue, unvisited, destinationNode);
//            return 0;

//        }


//    }
//}
