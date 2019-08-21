using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while(mainPlayer.GunRepository.Models.Any() && civilPlayers.Count!=0)
            {
                var currentGun = mainPlayer.GunRepository.Models.FirstOrDefault();
                var currentCivilPlayer = civilPlayers.FirstOrDefault();

                if(currentGun==null || currentCivilPlayer==null)
                {
                    break;
                }

                while (currentGun.CanFire && currentCivilPlayer.IsAlive)
                {
                    currentGun.Fire();

                    int lifePointsToTake = 0;

                    if(currentGun is Pistol)
                    {
                        lifePointsToTake = 1;
                    }
                    else
                    {
                        lifePointsToTake = 5;
                    }

                    currentCivilPlayer.TakeLifePoints(lifePointsToTake);
                }

                if(!currentGun.CanFire)
                {
                    mainPlayer.GunRepository.Remove(currentGun);
                }
                if(!currentCivilPlayer.IsAlive)
                {
                    civilPlayers.Remove(currentCivilPlayer);
                }
            }

            while(civilPlayers.Any())
            {
                var currentCivilPlayer = civilPlayers.FirstOrDefault();
                var currentGun = currentCivilPlayer.GunRepository.Models.FirstOrDefault();

                if (currentGun == null || currentCivilPlayer == null)
                {
                    break;
                }

                while (currentGun.CanFire && mainPlayer.IsAlive)
                {
                    currentGun.Fire();

                    int lifePointsToTake = 0;

                    if (currentGun is Pistol)
                    {
                        lifePointsToTake = 1;
                    }
                    else
                    {
                        lifePointsToTake = 5;
                    }

                    mainPlayer.TakeLifePoints(lifePointsToTake);
                }

                if (!currentGun.CanFire)
                {
                    currentCivilPlayer.GunRepository.Remove(currentGun);
                }
                if (!mainPlayer.IsAlive)
                {
                    break;
                }
            }
        }
    }
}
