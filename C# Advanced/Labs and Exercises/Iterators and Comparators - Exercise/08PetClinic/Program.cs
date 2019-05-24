using System;
using System.Linq;
using System.Collections.Generic;

namespace _08PetClinic
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Clinic> clinics = new List<Clinic>();
            List<Pet> pets = new List<Pet>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                string action = command[0];

                if (action == "Create" && command.Length == 5 && command[1]=="Pet")
                {
                    string name = command[2];
                    int age = int.Parse(command[3]);
                    string kind = command[4];

                    Pet pet = new Pet(name, age, kind);

                    pets.Add(pet);
                }
                else if (action== "Create" && command[1]=="Clinic")
                {
                    string clinicName = command[2];
                    int roomsCount = int.Parse(command[3]);

                    try
                    {
                        Clinic clinic = new Clinic(clinicName, roomsCount);

                        for (int r = 0; r < roomsCount; r++)
                        {
                            clinic.PetsRooms[r] = null;
                        }
                        clinics.Add(clinic);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action== "HasEmptyRooms")
                {
                    string clinicName = command[1];

                    Clinic clinicToCheck = clinics.Where(x => x.Name == clinicName).FirstOrDefault();

                    if (clinicToCheck.PetsRooms.Any(x => x == null))
                    {
                        Console.WriteLine("True");
                    }

                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (action == "Add")
                {
                    string petName = command[1];
                    string clinicName = command[2];

                    if(pets.Any(x=>x.Name==petName))
                    {
                        Pet petToAdd = pets.Where(x => x.Name == petName).FirstOrDefault();

                        Clinic clinicToAddPet = clinics.Where(x => x.Name == clinicName).FirstOrDefault();

                        if(clinicToAddPet.PetsRooms.Any(x=>x==null))
                        {
                            int counter = 0;

                            if(clinicToAddPet.PetsRooms.Length==1)
                            {
                                clinicToAddPet.PetsRooms[0] = petToAdd;
                                pets.Remove(petToAdd);
                                Console.WriteLine("True");
                                continue;
                            }

                            while (counter < clinicToAddPet.PetsRooms.Length/2)
                            {
                                if(clinicToAddPet.PetsRooms[clinicToAddPet.PetsRooms.Length/2]==null)
                                {
                                    clinicToAddPet.PetsRooms[clinicToAddPet.PetsRooms.Length / 2] = petToAdd;
                                    pets.Remove(petToAdd);
                                    Console.WriteLine("True");
                                    break;
                                }
                                else if(clinicToAddPet.PetsRooms[clinicToAddPet.PetsRooms.Length / 2 - counter-1] == null)
                                {
                                    clinicToAddPet.PetsRooms[clinicToAddPet.PetsRooms.Length / 2 - counter-1] = petToAdd;
                                    pets.Remove(petToAdd);
                                    Console.WriteLine("True");
                                    break;
                                }
                                else if (clinicToAddPet.PetsRooms[clinicToAddPet.PetsRooms.Length / 2 + counter+1] == null)
                                {
                                    clinicToAddPet.PetsRooms[clinicToAddPet.PetsRooms.Length / 2 + counter + 1] = petToAdd;
                                    pets.Remove(petToAdd);
                                    Console.WriteLine("True");
                                    break;
                                }

                                counter++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Operation!");
                    }
                }
                else if (action == "Release")
                {
                    string clinicName = command[1];

                    Clinic clinicToRelease = clinics.Where(x => x.Name == clinicName).FirstOrDefault();

                    if(clinicToRelease.PetsRooms.Any(x=>x!=null))
                    {
                        bool isBroken = false;

                        for (int g = clinicToRelease.PetsRooms.Length/2; g < clinicToRelease.PetsRooms.Length; g++)
                        {
                            if(clinicToRelease.PetsRooms[g]!=null)
                            {
                                clinicToRelease.PetsRooms[g] = null; 
                                Console.WriteLine("True");
                                isBroken = true;
                                break;
                            }
                        }

                        if(!isBroken)
                        {
                            for (int f = 0; f < clinicToRelease.PetsRooms.Length / 2; f++)
                            {
                                if(clinicToRelease.PetsRooms[f]!=null)
                                {
                                    clinicToRelease.PetsRooms[f] = null;
                                    Console.WriteLine("True");
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (action == "Print" && command.Length==2)
                {
                    string clinicName = command[1];

                    Clinic clinicToPrint = clinics.Where(x => x.Name == clinicName).FirstOrDefault();

                    foreach (Pet pet in clinicToPrint.PetsRooms)
                    {
                        if(pet!=null)
                        {                           
                            Console.WriteLine($"{pet.Name} {pet.Age} {pet.Kind}");
                        }
                        else
                        {
                            Console.WriteLine("Room empty");
                        }
                    }
                }
                else if (action == "Print" && command.Length == 3)
                {
                    string clinicName = command[1];
                    int roomNum = int.Parse(command[2]);
                    roomNum -= 1;

                    Clinic clinic = clinics.Where(x => x.Name == clinicName).FirstOrDefault();

                    Pet petToFind = clinic.PetsRooms[roomNum];

                    if(petToFind!=null)
                    {
                        Console.WriteLine($"{petToFind.Name} {petToFind.Age} {petToFind.Kind}");
                    }
                    else
                    {
                        Console.WriteLine("Room empty");
                    }
                }
            }
        }
    }
}
