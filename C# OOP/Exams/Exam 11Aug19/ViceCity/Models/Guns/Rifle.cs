using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private int bulletsShot;
        public Rifle(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel == 0)
            {
                if (this.TotalBullets > 0)
                {
                    this.BulletsPerBarrel = 50;
                    this.TotalBullets -= 50;
                }
            }

            if (this.TotalBullets != 0)
            {
                this.BulletsPerBarrel -= 5;

                this.bulletsShot += 5; 
            }

            return bulletsShot;
        }
    }
}
