using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class ManagerReservedList
    {
        static DBConection db = new DBConection();
        public static List<DTOReservedList> GetReserved_lists()
        {
            using (EazyShopEntities db = new EazyShopEntities())
            {
                Dictionary<string, int> colsStringList = new Dictionary<string, int>();

                List<Reserved_lists> listOfLists = db.GetDbSet<Reserved_lists>().ToList();
                foreach (var l in listOfLists)
                {
                    List<Products> productsOfList = l.Products_for_lists.Select(pfl => pfl.Products).ToList();
                    List<Columns> colFullList = db.GetDbSet<Columns>().ToList();
                    List<Columns> colForList = new List<Columns>();
                    foreach (var p in productsOfList)
                    {
                        Columns c = FindColForProd(p);
                        colForList.Add(c);
                    }
                    string colsString = "";
                    foreach (var col in colFullList)
                    {
                        if (colForList.Contains(col))
                            colsString += "1";
                        else
                            colsString += "0";
                    }
                    colsStringList.Add(colsString, l.List_code);
                }

                List<DTOReservedList> selectedLists = new List<DTOReservedList>();

                int l1=0;
                int l2=0;
                int numOfDiffCols = 4;
                for (int i = 0; i < colsStringList.Keys.ToList().Count; i++)
                {
                    string try1 = colsStringList.Keys.ToList()[i];
                    for (int j = 0; j < colsStringList.Count; j++)
                    {
                        string try2 = colsStringList.Keys.ToList()[j];

                        byte b1 = byte.Parse( try1);
                        byte b2 = byte.Parse( try2);
                        int b3 = b1 & b2;
                        byte b4= byte.Parse(b3.ToString());
                        string byteString = b4.ToString();
                        int count = 0;
                        for (int z = 0; z < byteString.Length; z++)
                        {
                            if (byteString[z] == '0')
                            {
                                count++;
                                if (count > 4)
                                    break;
                            }
                        }
                        if(count<=4)
                        {
                            l1 = colsStringList[try1];// שליפה של הקוד לפי המחרוזת
                            l2 = colsStringList[try2];
                            break;
                        }
                    }
                    if (l1 != 0 && l2 != 0)
                        break;
                }

                //Reserved_lists list1 = db.GetDbSet<Reserved_lists>().FirstOrDefault();
                //    Reserved_lists list2 = 
                //שליפה של רשימות בעלות קוד זהה ושליפת המוצרים ואיחוד הרשימות

                return null;
            }
        }

        public static Columns FindColForProd(Products p)
        {
            using (EazyShopEntities db = new EazyShopEntities())
            {
                Columns col = db.GetDbSet<Columns>().FirstOrDefault(c => c.Kod_Column == p.Kod_Column);
                return col;
            }

        }


    }
}
