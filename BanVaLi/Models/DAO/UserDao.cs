using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BanVaLi.Common;

namespace BanVaLi.Models.DAO
{
    public class UserDao
    {
        WebBanVaLiEntities1 db = new WebBanVaLiEntities1();

        public long Insert(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
            return user.ID;
        }
        public bool Login(string userName, string passWord)
        {
            var result = db.User.Count(x => x.Username == userName && x.Password == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User GetByName(string username)
        {
            return db.User.SingleOrDefault(x => x.Username == username);
        }

        public bool GetRoleUser(string username)
        {
            var user = db.User.FirstOrDefault(x => x.Username == username);
            var user_group = db.UserGroup.FirstOrDefault(x => x.ID == user.UserGroup_ID);
            if (user_group.Code == Base.IS_ADMIN)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}