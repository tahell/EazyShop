using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Algorithm
{
    // על פי ערך של הצומת (במשקל ) תור עדיפות
    public class PrioQueue : LinkedList<Node>//יורש מרישמה מרשימה מקושרת 
    {
        public void AddNodeWithPriority(Node node)//פונקציה שמקבלת צומת ומוסיפה אותה לתור על פי עדיפות 
        {
            if (this.Count == 0)//אם התור ריק
            {
                this.AddFirst(node);//תוסיף להתחילת התור את הצומת שקבלת 
            }
            else//זאת אומרת יש בתור צמתים קודמים- אם יש כבר משהו בתור
            {
                if (node.Value >= this.Last.Value.Value)//תבדוק האם הערך של הצומת שקבלתי גדול או שווה לערכה של הצומת שבסוף התור
                {
                    this.AddLast(node);//אם כן תוסיף את הצומת שקבלתי שפונקציה לסוף התור
                }
                else  //אם ערכה של הצומת קטנה מערכה של הצומת השוכנת בסוף בתור         
                {
                    for (LinkedListNode<Node> it = this.First; it != null; it = it.Next)//נעבור בלולאה מתחילת התור ועד סופו
                    {
                        if (node.Value <= it.Value.Value)  //אם מצאת צומת תוכדי מעבר גדולה יותר ממי שקבלת
                        {
                            this.AddBefore(it, node);//תכניס את הצומת שקיבלתי לפני הצומת הגדולה שמצאת
                            break;//תשבור תלולאה
                        }
                    }
                }
            }
        }

        public bool CheckNodeExists(Node n)
        {
            for (LinkedListNode<Node> it = this.First; it != null; it = it.Next)
            {
                if (it.Value == n) { return true; }
            }
            return false;
        }
    }
}
