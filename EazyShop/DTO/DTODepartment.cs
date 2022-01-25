using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTODepartment
    {
        public int Class_Code { get; set; }
        public string Class_Name { get; set; }

        public DTODepartment()
        {

        }
        public DTODepartment(Department d)
        {
            this.Class_Code = d.Class_Code;
            this.Class_Name = d.Class_Name;

        }
        public Department FromDTOToTable(DTODepartment dt)
        {
            Department d = new Department();
            d.Class_Code = dt.Class_Code;
            d.Class_Name = dt.Class_Name;
            return d;
        }

        public static List<DTODepartment> CreatDtoList(List<Department> d)
        {
            List<DTODepartment> dtolist = new List<DTODepartment>();
            foreach(var c in d)
            {
                DTODepartment dTO = new DTODepartment(c);
                dtolist.Add(dTO);
            }
            return dtolist;

        }






    }
}
