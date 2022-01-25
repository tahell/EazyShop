using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public class DTOProduct
    {
        public int Product_code { get; set; }
        public string Product_Name { get; set; }
        public int Kod_Category { get; set; }
        public int Location_Kod { get; set; }
        public int Price { get; set; }

        public DTOProduct()
        {

        }

        public DTOProduct(Product r)
        {
            this.Product_code = r.Product_code;
            this.Product_Name = r.Product_Name;
            this.Kod_Category = (int)r.Kod_Category;
            this.Location_Kod = (int)r.Location_Kod;


        }
        public Product FromDTOToTable(DTOProduct u)
        {
            Product us = new Product();
            us.Product_code = u.Product_code;
            us.Product_Name = u.Product_Name;
            us.Kod_Category = u.Kod_Category;
            us.Location_Kod = u.Location_Kod;
            return us;
        }

        public static List<DTOProduct> CreatDtoList(List<Product> d)
        {
            List<DTOProduct> dtolist = new List<DTOProduct>();
            foreach (var c in d)
            {
                DTOProduct dTO = new DTOProduct(c);
                dtolist.Add(dTO);
            }
            return dtolist;

        }
    }
}
