using airport_simulator_2019.Engine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airport_simulator_2019.GameObjects
{
    public class Player : GameObject
    {
        public ObservableCollection<Airplane> Airplanes { get; }
        public ObservableCollection<Flight> Flights { get; }
        public int Balance { get; private set; }
        public City HomeCity { get; private set; }
        public Schedule Schedule { get; private set; }

        public Player()
        {
            Airplanes = new ObservableCollection<Airplane>();
            Flights = new ObservableCollection<Flight>();
            Schedule = new Schedule();
            Balance = 100000000;
            HomeCity = CityCatalog.Cities.Find(x => x.Name == "Пермь");

            Flights.Add(Game.FlightBoard.GenerateFlight());
            BuyAirplane(Shop.Airplanes.First());
        }

        public void Spent(int howMuch)
        { 
            if (Balance >= howMuch)
            {
                Balance -= howMuch;
            }
        }

        public void Pay(int howMuch)
        {
            Balance += howMuch;
        }

        public void BuyAirplane(Airplane airplane)
        {
            int price = airplane.PriceBuy;
            if (Balance >= price)
            {
                Airplane plane = Game.Shop.Buy(airplane);
                Airplanes.Add(plane);
                Balance -= price;
            }
        }

        public void SaleAirplane(Airplane airplane)
        {
            if (!airplane.InRent)
            {
                Airplane plane = Game.Shop.Sale(airplane);
                Airplanes.Remove(plane);
                int priceSale = airplane.PriceSale;
                Balance += priceSale;
            }
        }

        public void RentAirplane(Airplane airplane, DateTime dateEnd)
        {
            int price = airplane.PriceRent;
            if (Balance >= price)
            {
                Airplane plane = Game.Shop.Rent(airplane, dateEnd);
                Airplanes.Add(plane);
                Balance -= price;
            }
        }

        public void ReturnRentedAirplane(Airplane airplane)
        {
            Airplanes.Remove(airplane);
            Game.Shop.ReturnRent(airplane);
        }

        public void TakeFromFlightBoard(Flight flight)
        {
            Flight taken = Game.FlightBoard.TakeFlight(flight);
            Flights.Add(taken);
        }

        public void ScheduleFlight(Flight flight, Airplane airplane, DateTime time)
        {
            Schedule.Add(flight, airplane, time);
        }

        public void TransferAirplane(Airplane airplane, City destination, DateTime time)
        {
            var flight = new Flight
            {
                Airplane = airplane,
                DepartureCity = airplane.Location,
                ArrivalCity = destination
            };
            ScheduleFlight(flight, airplane, time);
        }

        public void CompleteFlight(Airplane airplane)
        {
            Flight flight = Flights.First(x => x.Airplane == airplane);
            Pay(flight.PriceFlight);
            Schedule.CompleteFlight(flight);
            Flights.Remove(flight);
        }

        public override void OnDayBegin()
        {
            for (int i = Airplanes.Count - 1; i >= 0; i--)
            {
                Airplane airplane = Airplanes[i];
                if (airplane.InRent)
                {
                    if (Game.Time > airplane.RentEnd)
                    {
                        if (!airplane.InFly)
                        {
                            ReturnRentedAirplane(airplane);
                        }
                    }
                }
            }
            for (int i = Flights.Count - 1; i >= 0; i--)
            {
                Flight flight = Flights[i];
                if (Game.Time > flight.ExpireDate)
                {
                    Spent(flight.Forfeit);
                    Flights.Remove(flight);
                }
            }
        }
    }

}
