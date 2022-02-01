using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public static class ManagerLocation
    {
        static DBConection db = new DBConection();
        public static List<DTOLocation> GetLocation()
        {
            List<Location> list = db.GetDbSet<Location>().ToList();
            List<DTOLocation> dtolist = DTOLocation.CreatDtoList(list);
            return dtolist;
        }
    }
}
