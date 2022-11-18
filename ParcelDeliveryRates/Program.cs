// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

namespace ParcelDeliveryRates
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order()
            {
                Id = 1,
                PickupAddress = new Address()
                {
                    City = "Wien"
                },
                Recipients = new List<Customer>()
                {
                    new Customer()
                    {
                        Name = "Jozef",
                        Address = new Address()
                        {
                            City = "Namestovo"
                        },
                        Package = new Package()
                        {
                            Delivery = Delivery.SameDay,
                            PackageType = PackageType.Documents,
                        }
                    },
                    new Customer()
                    {
                        Name = "Julia",
                        Address = new Address()
                        {
                            City = "Bratislava"
                        },
                        Package = new Package()
                        {
                            Delivery = Delivery.TwoDays,
                            PackageType = PackageType.SmallParcel,
                        }
                    },
                    new Customer()
                    {
                        Name = "Miro",
                        Address = new Address()
                        {
                            City = "Brno"
                        },
                        Package = new Package()
                        {
                            Delivery = Delivery.SameDay,
                            PackageType = PackageType.LargeParcel,
                        }
                    },
                }
            };

            var repository = new PackageRepository();
            var rates = new RatesService(repository);
            var validation = new PackageValidation();
            var deliveryService = new DeliveryService(rates, validation);
            deliveryService.Send(order);
        }    
    }

    interface IDeliveryService
    {
        public void Send(Order order);
    }
    
    class DeliveryService : IDeliveryService
    {
        private readonly IRatesService _ratesService;
        private readonly IPackageValidation _packageValidation;

        public DeliveryService(IRatesService ratesService, IPackageValidation packageValidation)
        {
            _ratesService = ratesService;
            _packageValidation = packageValidation;
        }

        public void Send(Order order)
        {
            var isValid = _packageValidation.IsValid(order);
            if (!isValid)
            {
                throw new Exception("Cannot be send");
            }
            
            var deliveryCost = _ratesService.CalculateDelivery(order);
            foreach (var recipient in order.Recipients)
            {
                if (order.PickupAddress == recipient.Address)
                {
                    throw new Exception("pickup address cannot be the same with delivery address");
                }
                GetFromPickup(order.PickupAddress);
                TransferToDestination(recipient.Address);
            }
        }

        private void GetFromPickup(Address address)
        {
            Console.WriteLine("getting from pick up address");
        }

        private void TransferToDestination(Address address)
        {
            Console.WriteLine("transfering to destination");
        }
    }

    interface IPackageValidation
    {
        bool IsValid(Order order);
    }

    class PackageValidation : IPackageValidation
    {
        public bool IsValid(Order order)
        {
            foreach (var recipient in order.Recipients)
            {
                if (recipient.Address.City == "Tirol" && recipient.Package.Delivery == Delivery.SameDay)
                {
                    return false;
                }
            }

            return true;
        }
    }

    interface IRatesService
    {
        public decimal CalculateDelivery(Order order);
    }
    
    class RatesService : IRatesService
    {
        private readonly IPackageRepository _packageRepository;

        public RatesService(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public decimal CalculateDelivery(Order order)
        {
            var sum = 0.0m;
            foreach (var recipient in order.Recipients)
            {
                var package = _packageRepository.GetPackage(recipient.Package.PackageType, recipient.Package.Delivery);
                sum += package.Price;
            }
            
            sum = CalculateSameDayDiscount(order, sum);
            return sum;
        }

        private decimal CalculateSameDayDiscount(Order order, decimal sum)
        {
            var sameDay = true;
            foreach (var recipient in order.Recipients)
            {
                if (recipient.Package.Delivery != Delivery.SameDay)
                {
                    sameDay = false;
                }
            }

            if (sameDay)
            {
                return sum * 0.05m;
            }

            return sum;
        }
    }
    
    interface IPackageRepository
    {
        Package GetPackage(PackageType packageType, Delivery delivery);
    }
    
    class PackageRepository : IPackageRepository
    {
        public Package GetPackage(PackageType packageType, Delivery delivery)
        {
            switch (packageType)
            {
                case PackageType.Documents:
                    return new Package()
                    {
                        Description = "some documents",
                        PackageType = PackageType.Documents,
                        Price = delivery == Delivery.SameDay ? 4.00m : 1.00m
                    };
                case PackageType.SmallParcel:
                    return new Package()
                    {
                        Description = "this is small parcel",
                        PackageType = PackageType.SmallParcel,
                        Price = delivery == Delivery.SameDay ? 7.00m : 2.50m
                    };
                case PackageType.LargeParcel:
                    return new Package()
                    {
                        Description = "this is large parcel",
                        PackageType = PackageType.LargeParcel,
                        Price = delivery == Delivery.SameDay ? 9.00m : 3.00m
                    };
                default:
                    return new Package()
                    {
                        Description = "This type of package doesn't exist"
                    };
            }
        }
    }

    class Order
    {
        public int Id { get; set; }
        public List<Customer> Recipients { get; set; } = new List<Customer>();
        public Address PickupAddress { get; set; }
    }

    class Customer
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Package Package { get; set; }
    }

    class Address
    {
        public string City { get; set; }
    }

    class Package
    {
        public PackageType PackageType { get; set; }
        public Delivery Delivery { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
    
    enum Delivery
    {
        SameDay,
        TwoDays
    }

    enum PackageType
    {
        Documents,
        SmallParcel,
        LargeParcel
    }
}

