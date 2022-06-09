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

    //    public List<Products> MargetoLists(List<DTOProduct> a, List<DTOProduct> b)
    //    {
    //        Products p = new Products();
    //        List<Products> result = new List<Products>();
    //        int i = 0, j = 0, lastIndex = 0;
    //        while (i < a.Count() || j < b.Count())
    //            // If we're done with a, just gobble up b (but don't add duplicates)
    //            if (i >= a.Count())
    //                if (result[lastIndex] != b[j])
    //                    result[++lastIndex] = b[j];
           
            
    //    j++;
    //        //continue();

    //// If we're done with b, just gobble up a (but don't add duplicates)
    //        if (j >= b.Count())
    //            if (result[lastIndex] != a[i])
    //                result[++lastIndex] = a[i];
    //    i++;
    //    //continue

    //int smallestVal;

    //// Choose the smaller of a or b
    //        if (a[i] < b[j])
    //            smallestVal = a[i++]
    //else
    //            smallestVal = b[j++]

    //// Don't insert duplicates
    //        if (result[lastIndex] != smallestVal)
    //            result[++lastIndex] = smallestVal;
    //         end while
    //    }


    }



}
