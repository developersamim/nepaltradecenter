using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NepalTradeCenterWebAPI.Interface;
using NepalTradeCenterWebAPI.Models;

namespace NepalTradeCenterWebAPI.Controllers
{
    public class UserController : ApiController
    {
        private IGenericRepository<User> repository = null;

        public UserController()
        {
            this.repository = new GenericRepository<User>();
        }

        public void Post()
        {
            User user = new Admin();
            user.username = "admin";
            user.password = "admin";
            user.firstname = "admin";
            user.lastname = "admin";
            user.created = DateTime.Now;
            user.modified = DateTime.Now;
            user.modifier = "admin";

            repository.add(user);
            repository.saveChanges();
        }

        // PUT api/values/5
        public void Put(User user)
        {
            repository.update(user);
        }

        public void delete(int id)
        {
            repository.delete(id);
        }

        public User Get(int id)
        {
            return repository.get(id);
        }

        public IEnumerable<User> Get()
        {
            return repository.getAll();
        }
    }
}
