using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class ManagerProductForList
    {
        static DBConection db = new DBConection();
        public static List<DTOProductForList> GetProducts_for_lists()
        {
            List<Products_for_lists> list = db.GetDbSet<Products_for_lists>().ToList();
            List<DTOProductForList> dtolist = DTOProductForList.CreatDtoList(list);
            return dtolist;
        }
        //פונקציה שמוסיפה רשימה לרשימות
        public static List<Products_for_lists> ConectList(List<List<Products_for_lists>> pr)
        {
            List<Products_for_lists> p = new List<Products_for_lists>();
           foreach(var x in pr)
            {
                foreach(var y in x)
                {
                    p.Add(y);
                }
            }
            return p;
        }

        public static List<int> Listc(List<Products_for_lists> list_products, List<Products> prod)
        {
            List<int> list_colums = new List<int>();
            foreach(var x in list_products)
            {
                var y = db.GetDbSet<Products>().Where(r => r.Product_Code == x.Product_Code).ToList();
                foreach (var s in y)
                {
                    list_colums.Add(s.Kod_Column);
                }
            }
            return list_colums;



        }

    }
}
