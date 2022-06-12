using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using BL.DB;

namespace BL.Algoritms
{
    //טיפול בחישוב המסלול הקצר ביותר לביצוע הזמנות
    // בכל שלב נלקחות 3 ההזמנות בעלות ערך ההתאמה הגבוהה ביותר
    class PassNodes
    {
         Vertexes _startNode = DataBase._startNode;
        public static Dictionary<int, List<Vertexes>> _dicNodesToPrint;

        public void PassingNodes()
        {

            _dicNodesToPrint = new Dictionary<int, List<Vertexes>>();
            //בכל סבב  נתוני הקודקודים במפה מקבלים ערכים שונים
            // לכן יש צורך לשמר את נתוני המפה המקורית כדי להתחיל כל סבב חדש עם נתונים התחלתיים
            List<Vertexes> _orginalListNodes = CloneListNode(DataBase.listNodes, _startNode);
            List<int> _listNodeVisited = new List<int>();

            //שליפת הזמנות בעלות ערך ההתאמה של מחלקות הגבוהה ביותר
            List<Products> _itemListToSupply = CreateThreeOrdersCombination.GetItemsOfThreeBestOrders();

            List<Vertexes> _listNodeToSupply = new List<Vertexes>();
            //רשימת הקודקודים שבהן ישנם מוצרים להספקה
            _listNodeToSupply = (from x in DataBase.listNodes
                                 from y in DataBase._listLocation
                                 from z in _itemListToSupply
                                 
                                 where x.IDVertexes == y.IDVertexes  &&
                                       y.IDLocation == z.IDLocation.IDVertexes    
                                 select x).Distinct().ToList();

            for (int i = 0; i < _listNodeToSupply.Count(); i++)
            {
                ClearNode(_startNode);
                //חישוב המרחקים בין קודקוד התחלה לכל הקודקודים במפה
                CalcDIstance(_startNode);

                // מציאת קודקוד התחלה הבאה לפי ערכו הנמוך ביותר
                //מתוך רשימת הקודקודים שיש בהן מוצרים להספקה
                _startNode = (from x in (DataBase.listNodes.Where(x => !_listNodeVisited.Contains(x.IDVertexes)).OrderByDescending(x => x.nodeValue))
                              from y in (_listNodeToSupply)
                              where x.IDVertexes == y.IDVertexes
                              //select x).Last();
                              select new Vertexes()
                              {
                                  IDVertexes = x.IDVertexes,
                                  vertexColumn = x.vertexColumn,
                                  nodeIsViseted = x.nodeIsViseted,
                                  nodeName = x.nodeName,
                                  nodePreviousNode = x.nodePreviousNode,
                                  vertexRow = x.vertexRow,
                                  nodeValue = x.nodeValue,
                              }).Last();
                _listNodeVisited.Add(_startNode.IDVertexes);
                //רשימה השומרת לכול קודקוד יעד את המסלול  להגעה אליו 
                _dicNodesToPrint.Add(_startNode.IDVertexes, DataBase.listNodes);

                DataBase.listNodes = CloneListNode(_orginalListNodes, _startNode);
                foreach (passes _pass in DataBase.listPass)
                {
                    _pass.IDVertex1 = DataBase.listNodes.Find(x => x.IDVertexes == _pass.IDVertex1.IDVertexes);
                    _pass.IDVertex2 = DataBase.listNodes.Find(x => x.IDVertexes == _pass.IDVertex2.IDVertexes);
                }
            }

        }

        //חישוב המרחקים הקצרים ביותר בין קודקוד התחלה לכל הקודקודים במפה
        public void CalcDIstance(Vertexes startNode)
        {
            double _distance = 0;
            Vertexes _startNode = startNode;
            List<passes> _ListPass = new List<passes>();
            //סריקת כל המפה, כי חישוב הדרך הקצרה יכול לעבור גם בין קודקודים שאין בהן מוצרים להספקה 
            while (DataBase.listNodes.Where(x => !x.nodeIsViseted).Count() > 0)
            {
                //מעבר על הקשתות שיוצאים מקודקוד מסויים
                _ListPass = DataBase.listPass.FindAll(r => !r.IDVertex2.nodeIsViseted  && r.IDVertex1.IDVertexes == _startNode.IDVertexes).OrderBy(x => x.passDistance).ToList();

                foreach (passes _Pass in _ListPass)
                {
                    _distance = _startNode.nodeValue + CalcPass(_startNode, _Pass.IDVertex2);
                    if (_distance < _Pass.IDVertex2.nodeValue)
                    {
                        _Pass.IDVertex2.nodeValue = _distance;
                        //ההצבעה על הקודם
                        _Pass.IDVertex2.nodePreviousNode = _Pass.IDVertex1;
                    }
                }
                _startNode.nodeIsViseted = true;

                //קודקוד ההתחלה משתנה-דילוג לקודקוד בעל הערך הנמוך ביותר
                _startNode = DataBase.listNodes.Where(x => !x.nodeIsViseted).OrderBy(x => x.nodeValue).FirstOrDefault();
            }
        }

        //חישוב קשת
        double CalcPass(Vertexes fromNode, Vertexes toNode)
        {
            return (DataBase.listPass.Find(x => x.IDVertex1.IDVertexes == fromNode.IDVertexes && x.IDVertex2.IDVertexes == toNode.IDVertexes)).passDistance;
        }


        private List<Vertexes> CloneListNode(List<Vertexes> _fromlist, Vertexes startNode)
        {
            List<Vertexes> _listNodes = new List<Vertexes>();

            foreach (Vertexes _node in _fromlist)
            {
                _listNodes.Add(new Vertexes()
                {
                    vertexColumn = _node.vertexColumn,
                    IDVertexes = _node.IDVertexes,
                    nodeIsViseted = _node.nodeIsViseted,
                    nodeName = _node.nodeName,
                    nodePreviousNode = _node.nodePreviousNode,
                    vertexRow = _node.vertexRow,
                    nodeValue = _node.IDVertexes == startNode.IDVertexes ? 0 : int.MaxValue
                });
            }
            return _listNodes;
        }

        //אתחול צומת-מחיקת הערכים-ניקוי חלקי של הצומת בעבור המשך חישוב המסלול
        private void ClearNode(Vertexes _nodeToClear)
        {
            _nodeToClear.nodeIsViseted = false;
            _nodeToClear.nodePreviousNode = null;
            _nodeToClear.nodeValue = 0;

        }
       
        private void PrintWalkingPath()
        {
            List<Vertexes> _listNodes = new List<Vertexes>();
            Vertexes _startNode = new Vertexes();
            foreach (int _startNodeindex in _dicNodesToPrint.Keys)
            {
                _dicNodesToPrint.TryGetValue(_startNodeindex, out _listNodes);

                _startNode = _listNodes.Where(x => x.IDVertexes == _startNodeindex).LastOrDefault();
                printPath(_startNode);
            }
        }
        void printPath(Vertexes _printNode)
        {

            if (_printNode != null && _printNode.nodePreviousNode != null)
                printPath(_printNode.nodePreviousNode);
            System.Diagnostics.Debug.WriteLine("Node {0}", _printNode.IDVertexes);
        }
    }
}
