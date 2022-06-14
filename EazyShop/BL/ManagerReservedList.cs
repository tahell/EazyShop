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
            List<Reserved_lists> list = db.GetDbSet<Reserved_lists>().ToList();
            List<DTOReservedList> dtolist = DTOReservedList.CreatDtoList(list);
            return dtolist;
        }

        
    }
}
