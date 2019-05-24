namespace _08PetClinic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Clinic
    {
        public string Name { get; set; }

        public Pet[] PetsRooms { get; set; }

        public Clinic(string name, int rooms)
        {
            if(rooms%2!=0)
            {
                this.Name = name;
                this.PetsRooms = new Pet[rooms];
            }
            else
            {
                throw new Exception("Invalid Operation!");
            }
        }
    }
}
