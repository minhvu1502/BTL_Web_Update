using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVaLi.Models.DAO
{
    public class UserDao
    {
        WebBanVaLiEntities db = new WebBanVaLiEntities();

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
    }
}