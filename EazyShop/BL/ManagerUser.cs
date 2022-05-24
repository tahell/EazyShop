using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class ManagerUser
    {
        static DBConection db = new DBConection();
        public static List<DTOUser> GetUsers()
        {
            List<Users> list = db.GetDbSet<Users>().ToList();
            List<DTOUser> dtolist = DTOUser.CreatDtoList(list);
            return dtolist; 
        }

        public static DTOUser LoginUser(DTOUser user)
        {
            List<DTOUser> UserInDB = GetUsers();
            DTOUser us = UserInDB.FirstOrDefault(s => s.User_Name.Equals(user.User_Name) && s.Password.Equals(user.Password));
            if (us == null)
                return null;
            else if (us.Password != user.Password)
                return null;
            return us;
        }

        public static DTOUser RegisterUser(DTOUser U)
        {
            DBConection db = new DBConection();
            Users NewLogin = U.FromDTOToTable(U);
            db.Execute<Users>(NewLogin, DBConection.ExecuteActions.Insert);
            U.User_Code = NewLogin.User_Code;
            return U;
        }
    }
}
