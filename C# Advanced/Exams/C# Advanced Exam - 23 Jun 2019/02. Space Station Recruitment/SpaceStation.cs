namespace SpaceStationRecruitment
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Astronaut>();
        }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void Add(Astronaut astronaut)
        {
            if(this.data.Count<this.Capacity)
            {
                this.data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            if(this.data.Any(x=>x.Name==name))
            {
                Astronaut astronaut = this.data.FirstOrDefault(x => x.Name == name);
                this.data.Remove(astronaut);
                return true;
            }

            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            int maxAge = 0;
            Astronaut oldest = null;

            foreach (Astronaut astronaut in this.data)
            {
                if(astronaut.Age>maxAge)
                {
                    maxAge = astronaut.Age;
                    oldest = astronaut;
                }
            }

            return oldest;
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut astronaut = this.data.FirstOrDefault(x => x.Name == name);

            return astronaut;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (Astronaut astronaut in this.data)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
