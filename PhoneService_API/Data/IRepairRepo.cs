using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneService_API.Models;

namespace PhoneService_API.Data
{
    public interface IRepairRepo
    {
        //Persist changes
        bool SaveChanges();

        //Get All repairs from data
        IEnumerable<Repair> GetListRepairs();

        //Get Repair by ID
        Repair GetRepairById(int id);

        //Post Create new repair
        void NewRepair(Repair cmd);

        //Update repair
        void UpdateRepair(Repair cmd);

        //Delete repair
        void DeleteRepair(Repair cmd);
    }
}
