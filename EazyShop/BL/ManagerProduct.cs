using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class ManagerProduct
    {
        static DBConection db = new DBConection();
        public static List<DTOProduct> GetProducts()
        {
            List<Products> list = db.GetDbSet<Products>().ToList();
            List<DTOProduct> dtolist = DTOProduct.CreatDtoList(list);
            return dtolist;
        }
    }


    public List<Nodes> ConvertProductToNodes (List<Products> lp)
    {
        List<Nodes> ln = new List<Nodes>();
        List<int> lc = new List<int>();
        foreach( var x in lp)
        {
            lc.Add(x.Kod_Column);
        }

        return ln;
    }
}
