using airport_simulator_2019.Engine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airport_simulator_2019.GameObjects
{


    public class Player : GameObject
    {
        public TrulyObservableCollection<Airplane> Airplanes { get; }
        public TrulyObservableCollection<Flight> Flights { get; }
        public int Balance { get; private set; }
        public City HomeCity { get; private set; }
        public Schedule Schedule { get; private set; }

        public Player()
        {
            Airplanes = new TrulyObservableCollection<Airplane>();
            Flights = new TrulyObservableCollection<Flight>();
            Schedule = new Schedule();
            Balance = 100000000;
            HomeCity = CityCatalog.Cities.Find(x => x.Name == "Пермь");
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

                UpdateFlights();
            }
        }

        private void UpdateFlights()
        {
            foreach (var f in Game.FlightBoard.Flights)
            {
                f.RaisePropertyChanged();
            }

            foreach (var f in Flights)
            {
                f.RaisePropertyChanged();
            }
        }

        public void SaleAirplane(Airplane airplane)
        {
            if (!airplane.InRent)
            {
                Airplane plane = Game.Shop.Sale(airplane);
                Airplanes.Remove(plane);

                UpdateFlights();
            }
        }

        public void RentAirplane(Airplane airplane, DateTime dateEnd)
        {
            int price = airplane.PriceRent;
            if (Balance >= price)
            {
                Airplane plane = Game.Shop.Rent(airplane, dateEnd);
                Airplanes.Add(plane);

                UpdateFlights();
            }
        }

        public void ReturnRentedAirplane(Airplane airplane)
        {
            Airplanes.Remove(airplane);
            Game.Shop.ReturnRent(airplane);

            UpdateFlights();
        }

        public void TakeFromFlightBoard(Flight flight)
        {
            Flight taken = Game.FlightBoard.TakeFlight(flight);
            Flights.Add(taken);
        }

        public void RefuseFlight(Flight flight)
        {
            if (!flight.InFly)
            {
                Flights.Remove(flight);
                if (Schedule.Flights.Contains(flight))
                {
                    Schedule.Remove(flight);
                }
            }
        }

        public void ScheduleFlight(Flight flight, Airplane airplane, DateTime time)
        {
            Schedule.Add(flight, airplane, time);
        }

        public void RemoveFromSchedule(Flight flight)
        {
            Schedule.Remove(flight);
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
            Flight flight = Flights.FirstOrDefault(x => x.Airplane == airplane);
            if (flight != null)
            {
                flight.RaisePropertyChanged();
                Pay(flight.PriceFlight);
                Flights.Remove(flight);
            }
            Schedule.CompleteFlight(flight);

            Game.FlightComplete?.Invoke();
        }

        public override void OnDayBegin()
        {
            for (int i = Airplanes.Count - 1; i >= 0; i--)
            {
                Airplane airplane = Airplanes[i];
                if (airplane.InRent)
                {
                    if (Game.Time.Day > airplane.RentEnd.Value.Day)
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
