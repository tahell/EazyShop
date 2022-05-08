using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public class DTOTranition
    {
        public int Kod_Transition { get; set; }
        public int Class_Code { get; set; }
        public int Start_Kod { get; set; }
        public int End_Kod { get; set; }


        public DTOTranition()
        {

        }

        public DTOTranition(Transition T)
        {
            this.Kod_Transition = Kod_Transition;
            this.Class_Code = Class_Code;
            this.Start_Kod = Start_Kod;
            this.End_Kod = End_Kod;
        }

        public Transition FromDTOToTable(DTOTranition dt)
        {
            Transition d = new Transition();
            d.Kod_Transition = dt.Kod_Transition;
            d.Class_Code = dt.Class_Code;
            d.Start_Kod = dt.Start_Kod;
            d.End_Kod = dt.End_Kod;
            return d;
        }
        public static List<DTOTranition> CreatDtoList(List<Transition> d)
        {
            List<DTOTranition> dtolist = new List<DTOTranition>();
            foreach (var c in d)
            {
                DTOTranition dTO = new DTOTranition(c);
                dtolist.Add(dTO);
            }
            return dtolist;

        }
    }

}
