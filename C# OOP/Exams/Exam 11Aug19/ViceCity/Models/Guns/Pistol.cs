using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;
        private int bulletsShot = 0;
        public Pistol(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            if(this.BulletsPerBarrel==0)
            {
                if(this.TotalBullets>0)
                {
                    this.BulletsPerBarrel = 10;
                    this.TotalBullets -= 10;
                }
            }            

            if(this.TotalBullets!=0)
            {
                this.BulletsPerBarrel--;

                this.bulletsShot++;
            }

            return bulletsShot;
        }
    }
}
