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
        public int Kod_Column { get; set; }
        public int Shelf_number { get; set; }

        public DTOProduct()
        {

        }

        public DTOProduct(Products r)
        {
            this.Product_code = r.Product_Code;
            this.Product_Name = r.product_name;
            this.Kod_Category = (int)r.Kod_Category;
            this.Location_Kod = (int)r.Location_Code;
            this.Kod_Column = r.Kod_Column;
            this.Shelf_number = r.Shelf_number;


        }
        public Products FromDTOToTable(DTOProduct u)
        {
            Products us = new Products();
            us.Product_Code = u.Product_code;
            us.product_name = u.Product_Name;
            us.Kod_Category = u.Kod_Category;
            us.Location_Code = u.Location_Kod;
            us.Kod_Column = u.Kod_Column;
            us.Shelf_number = u.Shelf_number;
            return us;
        }

        public static List<DTOProduct> CreatDtoList(List<Products> d)
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
