using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneService_API.Models;

namespace PhoneService_API.Data
{
    public interface IUserRepo
    {
        User Get(string username, byte[] password);

        void Create(User user);

        //Update product
        void UpdateUser(User cmd);

        //Persist changes
        bool SaveChanges();
    }
}
