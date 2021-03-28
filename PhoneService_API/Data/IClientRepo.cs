using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using PhoneService_API.Models;

namespace PhoneService_API.Data
{
    public interface IClientRepo
    {
        //Persist changes
        bool SaveChanges();

        //Get All clients from data
        IEnumerable<Client> GetListOfClients();

        //Get client by ID
        Client GetClientById(int id);

        //Post Create new product
        void CreateClient(Client product);

        //Update client
        void UpdateClient(Client cmd);

        //Delete client
        void DeleteClient(Client product);
    }
}
