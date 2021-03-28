using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneService_API.Models;

namespace PhoneService_API.Data
{
    public class RepairRepo : IRepairRepo
    {
        private readonly AppDbContext _context;

        public RepairRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Repair> GetListRepairs()
        {
            return _context.Repair.ToList();
        }

        public Repair GetRepairById(int id)
        {
            return _context.Repair.FirstOrDefault(x => x.Id == id);
        }

        public void NewRepair(Repair cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Add(cmd);
        }

        public void UpdateRepair(Repair cmd)
        {
            //
        }

        public void DeleteRepair(Repair cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentException(nameof(cmd));
            }
            _context.Remove(cmd);
        }
    }
}
