using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class DTOReservedList
    {
        public int List_code { get; set; }
        public int User_Kod { get; set; }
        public DateTime Date { get; set; }
        public string Name_List { get; set; }

        public DTOReservedList()
        {

        }

        public DTOReservedList(Reserved_lists r)
        {
            this.List_code = r.List_code;
            this.User_Kod = (int)r.User_Kod;
            this.Date = (DateTime)r.Date;
            this.Name_List = r.Name_List;


        }
        public Reserved_lists FromDTOToTable(DTOReservedList u)
        {
            Reserved_lists us = new Reserved_lists();
            us.List_code = u.List_code;
            us.User_Kod = u.User_Kod;
            us.Date = u.Date;
            us.Name_List = u.Name_List;
            return us;
        }

        public static List<DTOReservedList> CreatDtoList(List<Reserved_lists> d)
        {
            List<DTOReservedList> dtolist = new List<DTOReservedList>();
            foreach (var c in d)
            {
                DTOReservedList dTO = new DTOReservedList(c);
                dtolist.Add(dTO);
            }
            return dtolist;

        }


    }
}
