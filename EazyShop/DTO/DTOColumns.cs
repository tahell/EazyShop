using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOColumns
    {
        public int Kod_Column { get; set; }
        public int Kod_Transition { get; set; }
        public int Number_shelves { get; set; }
        public bool StartOrEnd { get; set; }

        public DTOColumns()
        {

        }
        public DTOColumns(Columns c)
        {
            this.Kod_Column = Kod_Column;
            this.Kod_Transition = Kod_Transition;
            this.Number_shelves = Number_shelves;
            this.StartOrEnd = StartOrEnd;
        }

        public Columns FromDTOToTable(DTOColumns dt)
        {
            Columns d = new Columns();
            d.Kod_Column = dt.Kod_Column;
            d.Kod_Transition = dt.Kod_Transition;
            d.Number_shelves = dt.Number_shelves;
            d.StartOrEnd = dt.StartOrEnd;
            return d;
        }

        public static List<DTOColumns> CreatDtoList(List<Columns> d)
        {
            List<DTOColumns> dtolist = new List<DTOColumns>();
            foreach (var c in d)
            {
                DTOColumns dTO = new DTOColumns(c);
                dtolist.Add(dTO);
            }
            return dtolist;

        }
    }
}
