using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTOColum
    {
        public int Kod_Column { get; set; }
        public int Kod_Transition { get; set; }
        public int Number_shelves { get; set; }
        public DTOColum(Columns c)
        {
         
        }
        public DTOColum(DTOColum C)
        {
            this.Kod_Column = Kod_Column;
            this.Kod_Transition = Kod_Transition;
            this.Number_shelves = Number_shelves;
        }
        public Columns FromDTOToTable(DTOColum c)
        {
            Columns C = new Columns();
            C.Kod_Column = c.Kod_Column;
            C.Kod_Transition = c.Kod_Transition;
            C.Number_shelves = c.Number_shelves;
            return C;

        }

        public static List<DTOColum> CreatDtoList(List<Columns> d)
        {
            List<DTOColum> dtolist = new List<DTOColum>();
            foreach (var c in d)
            {
                DTOColum dTO = new DTOColum(c);
                dtolist.Add(dTO);
            }
            return dtolist;

        }


    }
}
