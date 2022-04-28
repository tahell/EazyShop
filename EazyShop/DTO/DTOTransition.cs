using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DTOTransition
   { 
    public int Kod_Transition { get; set; }
    public int Class_Code { get; set; }
    

    public DTOTransition()
    {

    }
    public DTOTransition(Transition d)
    {
        this.Kod_Transition = d.Kod_Transition;
        this.Class_Code = d.Class_Code;

    }
    public Transition FromDTOToTable(DTOTransition dt)
    {
            Transition d = new Transition();
        d.Kod_Transition = dt.Kod_Transition;
        d.Class_Code = dt.Class_Code;
        return d;
    }

    public static List<DTOTransition> CreatDtoList(List<Transition> d)
    {
        List<DTOTransition> dtolist = new List<DTOTransition>();
        foreach (var c in d)
        {
                DTOTransition dTO = new DTOTransition(c);
            dtolist.Add(dTO);
        }
        return dtolist;

    }
}
  }
