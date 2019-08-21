using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();

        public void Add(IGun model)
        {
            var gunName = model.Name;

            if(!this.models.Any(x=>x.Name==gunName))
            {
                this.models.Add(model);
            }
        }

        public IGun Find(string name)
        {
            var gun = this.models.FirstOrDefault(x => x.Name == name);

            return gun;
        }

        public bool Remove(IGun model)
        {
            var gun = this.models.FirstOrDefault(x => x.Name == model.Name);

            if(gun==null)
            {
                return false;
            }
            else
            {
                this.models.Remove(model);
                return true;
            }
        }
    }
}
