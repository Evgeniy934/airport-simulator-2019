using airport_simulator_2019.Engine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace airport_simulator_2019.GameObjects
{
    public class Shop : GameObject
    {
        private List<Airplane> _airplanes;

        public List<Airplane> Airplanes => _airplanes
            .Where(x => x.RentEnd == null)
            .ToList();

        public List<Airplane> Rents => _airplanes
            .Where(x => x.RentEnd != null)
            .ToList();

        public Airplane Rent(Airplane airplane, DateTime dateEnd)
        {
            _airplanes.Find(x => x == airplane).RentEnd = dateEnd;
            return airplane;
        }


        public Shop()
        {

            _airplanes = new List<Airplane>();

            _airplanes.Add(new Airplane
            {
                Name = "ТУ-134",
                QuantitySeat = 96,
                Speed = 850,
                DistanceFly = 2800,
                MaxLoad = 8300,
                Fuel = 8300,
                InFly = false,
                Location = "",
                PriceRent = 400000,
                PriceBuy = 5000000,
                PriceSale = 2500000,
                RentDate = -1
            });

            _airplanes.Add(new Airplane
            {
                Name = "ТУ-204",
                QuantitySeat = 214,
                Speed = 850,
                MaxLoad = 21000,
                DistanceFly = 4500,
                Fuel = 3500,
                InFly = false,
                Location = "",
                PriceRent = 550000,
                PriceBuy = 6000000,
                PriceSale = 3000000,
                RentDate = -1
            });

            _airplanes.Add(new Airplane
            {
                Name = "SSJ-100",
                QuantitySeat = 95,
                Speed = 950,
                DistanceFly = 3000,
                MaxLoad = 12200,
                Fuel = 2300,
                InFly = false,
                Location = "",
                PriceRent = 620000,
                PriceBuy = 8000000,
                PriceSale = 4000000,
                RentDate = -1
            });

            _airplanes.Add(new Airplane
            {
                Name = "ИЛ-62",
                QuantitySeat = 144,
                Speed = 850,
                DistanceFly = 6700,
                MaxLoad = 25000,
                Fuel = 7300,
                InFly = false,
                Location = "",
                PriceRent = 800000,
                PriceBuy = 8000000,
                PriceSale = 4000000,
                RentDate = -1
            });

            _airplanes.Add(new Airplane
            {
                Name = "ИЛ-86",
                QuantitySeat = 330,
                Speed = 950,
                DistanceFly = 4350,
                MaxLoad = 42000,
                Fuel = 9900,
                InFly = false,
                Location = "",
                PriceRent = 9500000,
                PriceBuy = 10000000,
                PriceSale = 5000000,
                RentDate = -1
            });

            _airplanes.Add(new Airplane
            {
                Name = "Boeing 737-800",
                QuantitySeat = 189,
                Speed = 850,
                DistanceFly = 5400,
                MaxLoad = 20500,
                Fuel = 2500,
                InFly = false,
                Location = "",
                PriceRent = 710000,
                PriceBuy = 3000000,
                PriceSale = 1500000,
                RentDate = -1
            });

            _airplanes.Add(new Airplane
            {
                Name = "Airbus A310",
                QuantitySeat = 218,
                Speed = 900,
                DistanceFly = 4000,
                MaxLoad = 33500,
                Fuel = 8300,
                InFly = false,
                Location = "",
                PriceRent = 660000,
                PriceBuy = 5500000,
                PriceSale = 2750000,
                RentDate = -1
            });

            _airplanes.Add(new Airplane
            {
                Name = "Boeing 747-400",
                QuantitySeat = 524,
                Speed = 920,
                DistanceFly = 13000,
                MaxLoad = 70000,
                Fuel = 11300,
                InFly = false,
                Location = "",
                PriceRent = 1500000,
                PriceBuy = 35000000,
                PriceSale = 175000000,
                RentDate = -1
            });

            _airplanes.Add(new Airplane
            {
                Name = "Boeing 767-300",
                QuantitySeat = 269,
                Speed = 910,
                DistanceFly = 9700,
                MaxLoad = 40200,
                Fuel = 4500,
                InFly = false,
                Location = "",
                PriceRent = 1100000,
                PriceBuy = 27000000,
                PriceSale = 13500000,
                RentDate = -1
            });

            _airplanes.Add(new Airplane
            {
                Name = "Airbus A330-300",
                QuantitySeat = 335,
                Speed = 870,
                DistanceFly = 10400,
                MaxLoad = 51700,
                Fuel = 5900,
                InFly = false,
                Location = "",
                PriceRent = 12000000,
                PriceBuy = 22000000,
                PriceSale = 11000000,
                RentDate = -1
            });
        }

        public Airplane Buy(Airplane airplane)
        {
            _airplanes.Remove(airplane);
            return airplane;
        }

        public override void DayBegin()
        {
            foreach (var item in _airplanes)
            {
                if (item.RentEnd != null)
                {
                    int payment = item.PriceRent;
                    Game.Player.Pay(payment);
                }
            }
        }

    }

}
