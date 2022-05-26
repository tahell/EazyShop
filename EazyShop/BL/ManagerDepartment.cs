using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public  class ManagerDepartment
    {
        static DBConection db = new DBConection();
        public static List<DTODepartment> GetDepartment()
        {
            List<Department> list = db.GetDbSet<Department>().ToList();
            List<DTODepartment> dtolist = DTODepartment.CreatDtoList(list);
            return dtolist;
        }
        public static List<DTOProduct> GetDepartmentAccordingCode(int CategoryNum)
        {
            List<Products> list = db.GetDbSet<Products>().Where(D => D.Kod_Category == CategoryNum).ToList();
            List<DTOProduct> dtolist = DTOProduct.CreatDtoList(list);
            return dtolist;
        }
    }
}