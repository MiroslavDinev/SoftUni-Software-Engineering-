using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            var customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            var salesXml = File.ReadAllText("../../../Datasets/sales.xml");

            using (var context = new CarDealerContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                var result = GetCarsWithTheirListOfParts(context);
                Console.WriteLine(result);
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierDto[]), new XmlRootAttribute("Suppliers"));

            var suppliersDtos = (SupplierDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDtos)
            {
                var supplier = new Supplier
                {
                    Name = supplierDto.Name,
                    IsImporter = supplierDto.isImporter
                };

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PartDto[]), new XmlRootAttribute("Parts"));

            var partsDtos = (PartDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var parts = new List<Part>();

            var suppliersIds = context.Suppliers
                .Select(s => s.Id)
                .ToList();

            foreach (var partDto in partsDtos)
            {
                if(suppliersIds.Contains(partDto.SupplierId))
                {
                    var part = new Part
                    {
                        Name = partDto.Name,
                        Price = partDto.Price,
                        Quantity = partDto.Quantity,
                        SupplierId = partDto.SupplierId
                    };

                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarsDto[]), new XmlRootAttribute("Cars"));

            var carsDtos = (CarsDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var partIds = context.Parts
                .Select(p => p.Id)
                .ToHashSet();

            foreach (var carDto in carsDtos)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                context.Cars.Add(car);

                var carsPartsIds = carDto.Parts
                    .Select(p => p.PartId)
                    .Distinct()
                    .ToArray();

                List<PartCar> partCars = new List<PartCar>();

                foreach (var carPartId in carsPartsIds)
                {
                    if(partIds.Contains(carPartId))
                    {
                        PartCar partCar = new PartCar
                        {
                            CarId = car.Id,
                            PartId = carPartId
                        };

                        partCars.Add(partCar);
                    }
                }

                context.PartCars.AddRange(partCars);
            }

            context.SaveChanges();
            
            return $"Successfully imported {context.Cars.Count()}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerDto[]), new XmlRootAttribute("Customers"));

            var customersDtos = (CustomerDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var customers = new List<Customer>();

            foreach (var customerDto in customersDtos)
            {
                var customer = new Customer
                {
                    Name = customerDto.Name,
                    BirthDate = customerDto.BirthDate,
                    IsYoungDriver = customerDto.isYoungDriver
                };

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaleDto[]), new XmlRootAttribute("Sales"));

            var salesDtos = (SaleDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var sales = new List<Sale>();

            var carsIds = context.Cars
                .Select(c => c.Id)
                .ToHashSet();

            foreach (var saleDto in salesDtos)
            {
                if(carsIds.Contains(saleDto.CarId))
                {
                    var sale = new Sale
                    {
                        CarId = saleDto.CarId,
                        CustomerId = saleDto.CustomerId,
                        Discount = saleDto.Discount
                    };

                    sales.Add(sale);
                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(x=> new ExportCarsWithDistanceDto
                {
                     Make = x.Make,
                     Model = x.Model,
                     TravelledDistance = x.TravelledDistance
                })
                .Take(10)
                .ToArray();


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithDistanceDto[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(x => new CarsFromBMWDto
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarsFromBMWDto[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(x => new ExportSupplierDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSupplierDto[]), new XmlRootAttribute("suppliers"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new ExportCarDto
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars
                    .Select(pc => new ExportPartDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarDto[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();

        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count != 0)
                .Select(x => new ExportCustomersWithBoughtCarsDto
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCustomersWithBoughtCarsDto[]), new XmlRootAttribute("customers"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new ExportSaleDiscount
                {
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = (x.Car.PartCars.Sum(pc => pc.Part.Price)) - (x.Car.PartCars.Sum(pc => pc.Part.Price) * x.Discount / 100),

                    Car = new ExportCarWithAttributesDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    }

                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSaleDiscount[]), new XmlRootAttribute("sales"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), sales, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}