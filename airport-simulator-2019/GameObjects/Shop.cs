using airport_simulator_2019.Engine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace airport_simulator_2019.GameObjects
{
    public class Shop : GameObject
    {
        public TrulyObservableCollection<Airplane> Airplanes { get; set; }
        private List<Airplane> _rent;

        public Shop()
        {
            Airplanes = new TrulyObservableCollection<Airplane>(GenerateAirplanes());
            _rent = new List<Airplane>();
        }

        public Airplane Buy(Airplane airplane)
        {
            Game.Player.Spent(airplane.PriceBuy);
            Airplanes.Remove(airplane);
            return airplane;
        }

        public Airplane Rent(Airplane airplane, DateTime dateEnd)
        {
            Game.Player.Spent(airplane.PriceRent);
            airplane.RentEnd = dateEnd;
            Airplanes.Remove(airplane);
            _rent.Add(airplane);
            return airplane;
        }        
        
        public void ReturnRent(Airplane airplane)
        {
            airplane.RentEnd = null;
            Airplanes.Add(airplane);
            _rent.Remove(airplane);
        }

        public Airplane Sale(Airplane airplane)
        {
            Game.Player.Pay(airplane.PriceSale);
            Airplanes.Add(airplane);
            return airplane;
        }

        public override void OnDayBegin()
        {
            for (int i = _rent.Count - 1; i >= 0; i--)
            {
                Airplane airplane = _rent[i];
                int payment = airplane.PriceRent;
                if (Game.Time > airplane.RentEnd.Value.AddDays(1))
                {
                    payment *= 2;
                }
                Game.Player.Spent(payment);
            }

            if (Game.Player.Balance < 0)
            {
                for (int i = Game.Player.Airplanes.Count - 1; i >= 0; i--)
                {
                    Airplane airplane = Game.Player.Airplanes[i];
                    if (airplane.InRent && !airplane.InFly)
                    {
                        Game.Player.ReturnRentedAirplane(airplane);
                    }
                }
            }
        }

        private List<Airplane> GenerateAirplanes()
        {
            City city = Game.Player.HomeCity;

            List<Airplane> airplanes = new List<Airplane>();
            airplanes.Add(new Airplane
            {
                Name = "ТУ-134",
                QuantitySeat = 96,
                Speed = 850,
                DistanceFly = 2800,
                MaxLoad = 8300,
                Fuel = 8300,
                Location = city,
                PriceRent = 400000,
                PriceBuy = 5000000,
                PriceSale = 2500000,
            });

            airplanes.Add(new Airplane
            {
                Name = "ТУ-204",
                QuantitySeat = 214,
                Speed = 850,
                MaxLoad = 21000,
                DistanceFly = 4500,
                Fuel = 3500,
                Location = city,
                PriceRent = 550000,
                PriceBuy = 6000000,
                PriceSale = 3000000,
            });

            airplanes.Add(new Airplane
            {
                Name = "SSJ-100",
                QuantitySeat = 95,
                Speed = 950,
                DistanceFly = 3000,
                MaxLoad = 12200,
                Fuel = 2300,
                Location = city,
                PriceRent = 620000,
                PriceBuy = 8000000,
                PriceSale = 4000000,
            });

            airplanes.Add(new Airplane
            {
                Name = "ИЛ-62",
                QuantitySeat = 144,
                Speed = 850,
                DistanceFly = 6700,
                MaxLoad = 25000,
                Fuel = 7300,
                Location = city,
                PriceRent = 800000,
                PriceBuy = 8000000,
                PriceSale = 4000000,
            });

            airplanes.Add(new Airplane
            {
                Name = "ИЛ-86",
                QuantitySeat = 330,
                Speed = 950,
                DistanceFly = 4350,
                MaxLoad = 42000,
                Fuel = 9900,
                Location = city,
                PriceRent = 9500000,
                PriceBuy = 10000000,
                PriceSale = 5000000,
            });

            airplanes.Add(new Airplane
            {
                Name = "Boeing 737-800",
                QuantitySeat = 189,
                Speed = 850,
                DistanceFly = 5400,
                MaxLoad = 20500,
                Fuel = 2500,
                Location = city,
                PriceRent = 710000,
                PriceBuy = 3000000,
                PriceSale = 1500000,
            });

            airplanes.Add(new Airplane
            {
                Name = "Airbus A310",
                QuantitySeat = 218,
                Speed = 900,
                DistanceFly = 4000,
                MaxLoad = 33500,
                Fuel = 8300,
                Location = city,
                PriceRent = 660000,
                PriceBuy = 5500000,
                PriceSale = 2750000,
            });

            airplanes.Add(new Airplane
            {
                Name = "Boeing 747-400",
                QuantitySeat = 524,
                Speed = 920,
                DistanceFly = 13000,
                MaxLoad = 70000,
                Fuel = 11300,
                Location = city,
                PriceRent = 1500000,
                PriceBuy = 35000000,
                PriceSale = 175000000,
            });

            airplanes.Add(new Airplane
            {
                Name = "Boeing 767-300",
                QuantitySeat = 269,
                Speed = 910,
                DistanceFly = 9700,
                MaxLoad = 40200,
                Fuel = 4500,
                Location = city,
                PriceRent = 1100000,
                PriceBuy = 27000000,
                PriceSale = 13500000,
            });

            airplanes.Add(new Airplane
            {
                Name = "Airbus A330-300",
                QuantitySeat = 335,
                Speed = 870,
                DistanceFly = 10400,
                MaxLoad = 51700,
                Fuel = 5900,
                Location = city,
                PriceRent = 1200000,
                PriceBuy = 22000000,
                PriceSale = 11000000,
            });

            airplanes.Add(new Airplane
            {
                Name = "ATR 42-500",
                QuantitySeat = 50,
                Speed = 556,
                DistanceFly = 2000,
                MaxLoad = 5450,
                Fuel = 450,
                Location = city,
                PriceRent = 450000,
                PriceBuy = 2800000,
                PriceSale = 1400000,
            });

            airplanes.Add(new Airplane
            {
                Name = "ATR 72-500",
                QuantitySeat = 70,
                Speed = 460,
                DistanceFly = 1200,
                MaxLoad = 7000,
                Fuel = 660,
                Location = city,
                PriceRent = 600000,
                PriceBuy = 3300000,
                PriceSale = 1650000,
            });

            airplanes.Add(new Airplane
            {
                Name = "Saab 2000",
                QuantitySeat = 50,
                Speed = 560,
                DistanceFly = 2100,
                MaxLoad = 5500,
                Fuel = 820,
                Location = city,
                PriceRent = 550000,
                PriceBuy = 3000000,
                PriceSale = 1500000,
            });

            airplanes.Add(new Airplane
            {
                Name = "SAAB-340B Plus",
                QuantitySeat = 37,
                Speed = 460,
                DistanceFly = 1500,
                MaxLoad = 3900,
                Fuel = 400,
                Location = city,
                PriceRent = 250000,
                PriceBuy = 1800000,
                PriceSale = 900000,
            });

            airplanes.Add(new Airplane
            {
                Name = "МС-21-200",
                QuantitySeat = 160,
                Speed = 870,
                DistanceFly = 6400,
                MaxLoad = 18900,
                Fuel = 1800,
                Location = city,
                PriceRent = 920000,
                PriceBuy = 6000000,
                PriceSale = 3000000,
            });

            airplanes.Add(new Airplane
            {
                Name = "Fokker 100",
                QuantitySeat = 107,
                Speed = 820,
                DistanceFly = 3100,
                MaxLoad = 12000,
                Fuel = 2150,
                Location = city,
                PriceRent = 800000,
                PriceBuy = 4500000,
                PriceSale = 2250000,
            });

            airplanes.Add(new Airplane
            {
                Name = "Ан-3Т",
                QuantitySeat = 12,
                Speed = 250,
                DistanceFly = 1200,
                MaxLoad = 1800,
                Fuel = 250,
                Location = city,
                PriceRent = 50000,
                PriceBuy = 400000,
                PriceSale = 200000,
            });

            airplanes.Add(new Airplane
            {
                Name = "Ан-148-100В",
                QuantitySeat = 78,
                Speed = 820,
                DistanceFly = 3600,
                MaxLoad = 9000,
                Fuel = 1600,
                Location = city,
                PriceRent = 250000,
                PriceBuy = 900000,
                PriceSale = 450000,
            });

            airplanes.Add(new Airplane
            {
                Name = "Ту-154М",
                QuantitySeat = 170,
                Speed = 900,
                DistanceFly = 3900,
                MaxLoad = 18000,
                Fuel = 5300,
                Location = city,
                PriceRent = 660000,
                PriceBuy = 3900000,
                PriceSale = 1950000,
            });

            airplanes.Add(new Airplane
            {
                Name = "Ту-334-100",
                QuantitySeat = 102,
                Speed = 820,
                DistanceFly = 3100,
                MaxLoad = 12000,
                Fuel = 1700,
                Location = city,
                PriceRent = 500000,
                PriceBuy = 3000000,
                PriceSale = 1500000,
            });

            return airplanes;
        }
    }

}
