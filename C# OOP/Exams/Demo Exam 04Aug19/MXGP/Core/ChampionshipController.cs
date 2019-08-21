using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Races;
using MXGP.Models.Riders;
using MXGP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private RiderRepository riderRepository;
        private MotorcycleRepository motorcycleRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            this.riderRepository = new RiderRepository();
            this.motorcycleRepository = new MotorcycleRepository();
            this.raceRepository = new RaceRepository();
        }
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riderRepository.GetByName(riderName);
            var motorcycle = this.motorcycleRepository.GetByName(motorcycleModel);

            if(rider==null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            if(motorcycle==null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            rider.AddMotorcycle(motorcycle);
            return $"Rider {riderName} received motorcycle {motorcycleModel}.";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var rider = this.riderRepository.GetByName(riderName);
            var race = this.raceRepository.GetByName(raceName);

            if(race==null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if(rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            race.AddRider(rider);
            return $"Rider {riderName} added in {raceName} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var allMotorcycles = this.motorcycleRepository.GetAll();

            foreach (var currMotorcycle in allMotorcycles)
            {
                if(currMotorcycle.Model==model)
                {
                    throw new ArgumentException($"Motorcycle {model} is already created.");
                }
            }

            Motorcycle motorcycle = null;

            if(type=="Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }
            else if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }

            this.motorcycleRepository.Add(motorcycle);

            return $"{motorcycle.GetType().Name} {model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            var allRaces = this.raceRepository.GetAll();

            foreach (var currRace in allRaces)
            {
                if(currRace.Name == name)
                {
                    throw new InvalidOperationException($"Race {name} is already created.");
                }
            }

            var race = new Race(name,laps);
            this.raceRepository.Add(race);

            return $"Race {name} is created.";
        }

        public string CreateRider(string riderName)
        {
            var allRiders = this.riderRepository.GetAll();

            foreach (var currRider in allRiders)
            {
                if(currRider.Name == riderName)
                {
                    throw new ArgumentException($"Rider {riderName} is already created.");
                }
            }

            var rider = new Rider(riderName);
            this.riderRepository.Add(rider);

            return $"Rider {riderName} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.GetByName(raceName);

            if(race==null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if(race.Riders.Count<3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var arrangedRiders = race.Riders
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps));

            StringBuilder sb = new StringBuilder();

            int counter = 0;

            foreach (var rider in arrangedRiders)
            {
                if(counter==3)
                {
                    break;
                }
                else if (counter==0)
                {
                    sb.AppendLine($"Rider {rider.Name} wins {raceName} race.");
                }
                else if (counter==1)
                {
                    sb.AppendLine($"Rider {rider.Name} is second in {raceName} race.");
                }
                else if (counter==2)
                {
                    sb.AppendLine($"Rider {rider.Name} is third in {raceName} race.");
                }
                counter++;
            }

            this.raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
