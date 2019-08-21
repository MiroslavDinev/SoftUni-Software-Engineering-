using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RiderRepository : IRepository<IRider>
    {
        private readonly List<IRider> riders;

        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }
        public void Add(IRider model)
        {
            this.riders.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.riders;
        }

        public IRider GetByName(string name)
        {
            var rider = this.riders.FirstOrDefault(x => x.Name == name);
            return rider;
        }

        public bool Remove(IRider model)
        {
            bool isRemoved = this.riders.Remove(model);
            return isRemoved;
        }
    }
}
