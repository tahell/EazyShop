using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class ManagerTransition
    {
        static DBConection db = new DBConection();
        public static List<DTOTransition> GetTransition()
        {
            List<Transition> list = db.GetDbSet<Transition>().ToList();
            List<DTOTransition> dtolist = DTOTransition.CreatDtoList(list);
            return dtolist;
        }
    }
}
