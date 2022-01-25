using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
   public class DTOProductForList
   {
        public int Product_code_for_the_list_ { get; set; }
        public int Product_Code { get; set; }
        public int Kod_List { get; set; }
        public DTOProductForList()
        {

        }
        public DTOProductForList(Products_for_lists r)
        {
            this.Product_code_for_the_list_ = r.Product_code_for_the_list_;
            this.Product_Code = (int)r.Product_Code;
            this.Kod_List = (int)r.Kod_List;
            


        }
        public Products_for_lists FromDTOToTable(DTOProductForList u)
        {
            Products_for_lists us = new Products_for_lists();
            us.Product_code_for_the_list_ = u.Product_code_for_the_list_;
            us.Product_Code = u.Product_Code;
            us.Kod_List = u.Kod_List;
            return us;
        }

        public static List<DTOProductForList> CreatDtoList(List<Products_for_lists> d)
        {
            List<DTOProductForList> dtolist = new List<DTOProductForList>();
            foreach (var c in d)
            {
                DTOProductForList dTO = new DTOProductForList(c);
                dtolist.Add(dTO);
            }
            return dtolist;

        }
    }
}
