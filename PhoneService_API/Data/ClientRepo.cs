using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhoneService_API.Models;

namespace PhoneService_API.Data
{
    public class ClientRepo : IClientRepo
    {

        private readonly AppDbContext _context;

        public ClientRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Client> GetListOfClients()
        {
            return _context.Client.ToList();
        }

        public Client GetClientById(int id)
        {
            var client = _context.Client.FirstOrDefault(x => x.Id == id);
            if (client == null)
                throw new CultureNotFoundException($"There is no Client with selected ID : {id}");
            else
                return client;
        }

        public void CreateClient(Client client)
        {
            _context.Client.Add(client);
        }

        public void UpdateClient(Client cmd)
        {
            //EntityEntry dbEntityEntry = _context.Entry(cmd);
            //dbEntityEntry.State = EntityState.Modified;
        }

        public void DeleteClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            _context.Client.Remove(client);
        }
    }
}
