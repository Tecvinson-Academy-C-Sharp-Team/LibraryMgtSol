using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryMgt.Core.Entities;

namespace LibraryMgt.Core.IService
{
    public interface IUserService
    {
        public void CreateUser(User user);

        public void CreateUser(string name, string email);

        public User GetUserById(long id);
    }
}