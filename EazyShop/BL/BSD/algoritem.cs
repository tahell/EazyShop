using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BSD
{
    class algoritem
    {

        static DBConection db = new DBConection();


        //רשימה של כל הצמתים הראשונים -כל הגרף כל הסופר-עובד
        List<Nodes> AllNodes = db.GetDbSet<Nodes>();


        // עובד-רשימה של כל הקשתות בכל הסופר 
        List<Route> AllRoute = CreateRouteForSuper();


        //מקבלים את הרשימה של הצצמתים שנבחרו   
        List<Nodes> choce = new List<Nodes>();






        //dikjstra(AllRoute, AllNodes);









        //יוצר רשימת קשתות בכל הסופר
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

        //2 להפעיל את הדייאקסטראה על הכל הסופר



        public void dikjstra(List<Route> AllRoute, List<Nodes> AllNodes) {

            for (int i = 0; i < AllNodes.Count(); i++)
            {
                //לכל צומת מוצאים את כל הקשתות שלו ועוברים עלייהם 
                List<Route> r = AllRoute.Where(s=>s.source.Node_Kod==AllNodes[i].Node_Kod).ToList();
                //מגדירים מרחק הכי גדול שיש
                double min = int.MaxValue;
                for(int j = 0; j < r.Count(); j++)
                {
                    if (r[j].value < min)
                    {
                        min = r[j].value;
                    }
                    

                }
            }

        //{
        //    ///פה אני צריכה לעשות נקודת עצירה 
        //    //תנאי עצירה בחיפוש מסלול קצר בין כל הנקודות בגרף
        //    if (queue.Count == 0)
        //    {
        //        return;
        //    }
        //    //תנאי עצירה בחיפוש מסלול קצר בין מקור ליעד
        //    if (lastNode != null && destinationNode != null && lastNode.Store.NameStor.Equals(destinationNode.Store.NameStor))
        //    {
        //        return;
        //    }
        //    //רשימת קשתות של צומת 
        //    List<Route> neighborRoutes = routes.Where(s => s.From.Equals(queue.First.Value)).ToList();
        //    foreach (var r in neighborRoutes)
        //    {
        //        //אם קוד היעד לא נמצא ברשימה שצריך לבקר בה סימן שביקרו בו - נדלג עליו
        //        if (!unvisited.Contains(r.To))
        //        {
        //            continue;
        //        }
        //        //מעדכנת מה המרחק עד לצומת הנוכחית - מה היה המרחק עד הגעה לצומת הנוחכית 
        //        double travelDistance = nodes[queue.First.Value.Store.NameStor].Value + r.Distance;
        //        //בדיקה האם מה שחישבתי עכשיו יותר קצר ממה שקיים בצומת היעד עד עכשיו 
        //        if (travelDistance < nodes[r.To.Store.NameStor].Value)
        //        {
        //            //אם כן -תעדכן 
        //            nodes[r.To.Store.NameStor].Value = travelDistance;
        //            //הקודם 
        //            nodes[r.To.Store.NameStor].PreviousNode = r.From;
        //            //  travelDistance צריך פה גם לעדכן שוב את ה
        //        }
        //        if (!queue.HasLetter(r.To))
        //        {
        //            queue.AddNodeWithPriority(r.To);
        //        }
        //    }
        //    unvisited.Remove(queue.First.Value);
        //    lastNode = nodes[queue.First.Value.Store.NameStor];
        //    queue.RemoveFirst();
        //    CheckNode(routes, nodes, queue, unvisited, destinationNode, ref lastNode, ref dist);
        //    return;
        //}
        }
    }
}








           



   

