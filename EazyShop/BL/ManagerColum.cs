using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class ManagerColum
    {
        static DBConection db = new DBConection();
        public static List<DTOColum> GetColum()
        {
            List<Columns> list = db.GetDbSet<Columns>().ToList();
            List<DTOColum> dtolist = DTOColum.CreatDtoList(list);
            return dtolist;
        }
    }
}
