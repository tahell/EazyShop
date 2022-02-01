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
}
