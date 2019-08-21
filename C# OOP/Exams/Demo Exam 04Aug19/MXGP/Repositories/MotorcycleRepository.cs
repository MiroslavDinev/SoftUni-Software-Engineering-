using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly List<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<IMotorcycle>();
        }
        public void Add(IMotorcycle model)
        {
            this.motorcycles.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return this.motorcycles;
        }

        public IMotorcycle GetByName(string name)
        {
            var motorcycle = this.motorcycles.FirstOrDefault(x => x.Model == name);
            return motorcycle;
        }

        public bool Remove(IMotorcycle model)
        {
            bool isRemoved = this.motorcycles.Remove(model);
            return isRemoved;

        }
    }
}
