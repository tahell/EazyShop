using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public class DTOUser
    {
        public int User_Code { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }

        public DTOUser()
        {

        }

        public DTOUser(User u)
        {
            this.User_Code = u.User_Code;
            this.User_Name = u.User_Name;
            this.Password = u.Password;
        }
        public User FromDTOToTable(DTOUser u)
        {
            User us = new User();
            us.User_Code = u.User_Code;
            us.User_Name = u.User_Name;
            us.Password = u.Password;
            return us;
        }

        public static List<DTOUser> CreatDtoList(List<User> d)
        {
            List<DTOUser> dtolist = new List<DTOUser>();
            foreach (var c in d)
            {
                DTOUser dTO = new DTOUser(c);
                dtolist.Add(dTO);
            }
            return dtolist;

        }

    }
}
