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
    }
}
