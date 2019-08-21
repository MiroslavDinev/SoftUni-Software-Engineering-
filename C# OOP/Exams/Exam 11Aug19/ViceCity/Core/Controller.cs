using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private IPlayer mainPlayer;
        private List<IPlayer> civilPlayers;
        private List<IGun> guns;
        private GangNeighbourhood gangNeighbourhood;
        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.civilPlayers = new List<IPlayer>();
            this.guns = new List<IGun>();
            this.gangNeighbourhood = new GangNeighbourhood();
        }
        public string AddGun(string type, string name)
        {
            IGun gun = null;

            if(type== "Pistol")
            {
                gun = new Pistol(name);
                this.guns.Add(gun);
                return $"Successfully added {name} of type: {type}";
            }
            else if (type== "Rifle")
            {
                gun = new Rifle(name);
                this.guns.Add(gun);
                return $"Successfully added {name} of type: {type}";
            }
            else
            {
                return "Invalid gun type!";
            }
        }

        public string AddGunToPlayer(string name)
        {
            if(this.guns.Count==0)
            {
                return $"There are no guns in the queue!";
            }

            var gunToAdd = this.guns.FirstOrDefault();

            if(name== "Vercetti")
            {
                mainPlayer.GunRepository.Add(gunToAdd);
                this.guns.Remove(gunToAdd);
                return $"Successfully added {gunToAdd.Name} to the Main Player: Tommy Vercetti";
            }

            var civilPlayer = this.civilPlayers.FirstOrDefault(x => x.Name == name);

            if(civilPlayer==null)
            {
                return "Civil player with that name doesn't exists!";
            }

            civilPlayer.GunRepository.Add(gunToAdd);
            this.guns.Remove(gunToAdd);
            return $"Successfully added {gunToAdd.Name} to the Civil Player: {civilPlayer.Name}";
        }

        public string AddPlayer(string name)
        {
            var civilPlayer = new CivilPlayer(name);
            this.civilPlayers.Add(civilPlayer);

            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            StringBuilder sb = new StringBuilder();

            int initialCivilPLayersCount = this.civilPlayers.Count();

            this.gangNeighbourhood.Action(mainPlayer, this.civilPlayers);

            if(mainPlayer.LifePoints==100 && this.civilPlayers.All(x=>x.LifePoints==50))
            {
                return "Everything is okay!";
            }
            else
            {
                int deadCivilPlayersCount = initialCivilPLayersCount - this.civilPlayers.Count();
                sb.Append("A fight happened:" + 
                    Environment.NewLine + $"Tommy live points: {mainPlayer.LifePoints}!" + 
                    Environment.NewLine + $"Tommy has killed: {deadCivilPlayersCount} players!" + 
                    Environment.NewLine + $"Left Civil Players: {this.civilPlayers.Count}!");

                return sb.ToString().TrimEnd();
            }
        }
    }
}
