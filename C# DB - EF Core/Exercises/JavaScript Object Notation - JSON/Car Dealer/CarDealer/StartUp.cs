using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            var salesJson = File.ReadAllText(@"D:\Miro\SoftUni\C# DB\EF CORE\Feb 19\10 JSON Processing\Car Dealer - Skeleton\CarDealer\Datasets\sales.json");
            var result = GetCarsFromMakeToyota(context);
            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var validSupplierIds = context.Suppliers
                .Select(s => s.Id)
                .ToList();

            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(p => validSupplierIds.Contains(p.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<List<CarPartsDto>>(inputJson);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CarPartsDto, Car>();

            });

            var mapper = config.CreateMapper();

            HashSet<int> validPartsIds = context.Parts
                .Select(p => p.Id)
                .ToHashSet();

            var validCars = new List<CarPartsDto>();

            foreach (var car in carsDto)
            {
                bool isValid = false;

                foreach (var currId in car.PartsId)
                {
                    if (validPartsIds.Contains(currId))
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    validCars.Add(car);
                }
            }

            for (int i = 0; i < validCars.Count; i++)
            {
                var carTemp = mapper.Map<Car>(validCars[i]);

                foreach (var partId in validCars[i].PartsId.Distinct())
                {
                    carTemp.PartCars.Add(new PartCar { CarId = i + 1, PartId = partId });
                }

                context.Add(carTemp);
            }

            context.SaveChanges();

            return $"Successfully imported {validCars.Count}.";

        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance,
                    },
                        parts = c.PartCars.Select(pc => new
                        {
                            Name = pc.Part.Name,
                            Price = $"{pc.Part.Price:f2}"
                        })
                    }).ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count != 0)
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count,
                    spentMoney = x.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(x=>x.spentMoney)
                .ThenByDescending(x=>x.boughtCars)
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var cars = context.Sales
                .Select(c => new
            {
                car = new
                {
                    Make = c.Car.Make,
                    Model = c.Car.Model,
                    TravelledDistance = c.Car.TravelledDistance
                },
                customerName = c.Customer.Name,
                Discount = c.Discount.ToString("F2"),
                price = c.Car.PartCars.Sum(x => x.Part.Price).ToString("F2"),
                priceWithDiscount = (c.Car.PartCars.Sum(x => x.Part.Price) -
                                        (c.Car.PartCars.Sum(x => x.Part.Price) * (c.Discount / 100))).ToString("F2")
            })
                .ToList()
                .Take(10);

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }
    }
}
