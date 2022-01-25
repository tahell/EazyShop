using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public class DTOLocation
    {
        public int Location_Kod { get; set; }
        public int Value_X { get; set; }
        public int Value_Y { get; set; }

        public DTOLocation()
        {

        }

        public DTOLocation(Location r)
        {
            this.Location_Kod = r.Location_Kod;
            this.Value_X = (int)r.Value_X;
            this.Value_Y = (int)r.Value_Y;



        }
        public Location FromDTOToTable(DTOLocation u)
        {
            Location us = new Location();
            us.Location_Kod = u.Location_Kod;
            us.Value_X = u.Value_X;
            us.Value_Y = u.Value_Y;
            return us;
        }

        public static List<DTOLocation> CreatDtoList(List<Location> d)
        {
            List<DTOLocation> dtolist = new List<DTOLocation>();
            foreach (var c in d)
            {
                DTOLocation dTO = new DTOLocation(c);
                dtolist.Add(dTO);
            }
            return dtolist;

        }
    }
}
