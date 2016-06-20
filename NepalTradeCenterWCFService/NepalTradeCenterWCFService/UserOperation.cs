using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NepalTradeCenterWCFService
{
    public class UserOperation
    {
        MyContext myContext;
        public UserOperation()
        {
            myContext = new MyContext();
        }

        public User authentiateUser(string username, string password)
        {
            using (myContext)
            {
                int userId = (from x in myContext.Users where x.username == username & x.password == password select x.userId).SingleOrDefault();

                if (userId > 0)
                {
                    // user exists
                    return myContext.Users.Find(userId);
                }
                else
                {
                    // user does not exist
                    return null;
                }
            }
        }
    }
}