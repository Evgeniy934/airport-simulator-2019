using airport_simulator_2019.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airport_simulator_2019.GameObjects
{
    public class Player : GameObject
    {
        public List<Airplane> Airplanes { get; }
        public List<Flight> Flights { get; }
        public int Balance { get; private set; }
        public City HomeCity { get; private set; }
        public Schedule Schedule { get; private set; }

        public Player()
        {
            Airplanes = new List<Airplane>();
            Flights = new List<Flight>();
            Schedule = new Schedule();
            Balance = 100000000;
            HomeCity = CityCatalog.Cities.Find(x => x.Name == "Пермь");

            Flights.Add(Game.FlightBoard.GenerateFlight());
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
            int price = Game.Shop.Airplanes.Find(x => x == airplane).PriceBuy;
            if (Balance >= price)
            {
                Airplane plane = Game.Shop.Buy(airplane);
                Airplanes.Add(plane);
                Balance -= price;
            }
        }

        public void SaleAirplane(Airplane airplane)
        {
            int rent = airplane.RentDays;
            if (rent == -1)
            {
                Airplane plane = Game.Shop.Sale(airplane);
                Airplanes.Remove(plane);
                int priceSale = airplane.PriceSale;
                Balance += priceSale;
            }
            
        }

        public void RentAirplane(Airplane airplane, DateTime dateEnd)
        {
            int price = Game.Shop.Airplanes.Find(x => x == airplane).PriceRent;
            if (Balance >= price)
            {
                Airplane plane = Game.Shop.Rent(airplane, dateEnd);
                Airplanes.Add(plane);
                Balance -= price;
            }
        }

        public void TakeFromFlightBoard(Flight flight)
        {
            Flight taken = Game.FlightBoard.TakeFlight(flight);
            Flights.Add(taken);
        }

        public void ReturnRentedAirplane(Airplane airplane)
        {
            Airplanes.Remove(airplane);
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

    }

}
