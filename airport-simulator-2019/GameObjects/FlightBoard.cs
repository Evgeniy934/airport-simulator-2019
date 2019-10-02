using airport_simulator_2019.Engine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace airport_simulator_2019.GameObjects
{
    public class FlightBoard : GameObject
    {
        private static Random _random = new Random();

        public TrulyObservableCollection<Flight> Flights { get; private set; }

        public FlightBoard()
        {
            Flights = new TrulyObservableCollection<Flight>(GenerateFlights());
        }

        public Flight TakeFlight(Flight flight)
        {
            Flights.Remove(flight);
            return flight;
        }

        public override void OnDayBegin()
        {
            for (int i = Flights.Count - 1; i >= 0; i--)
            {
                Flight flight = Flights[i];
                if (Game.Time.DayOfYear >= flight.ExpireDate.DayOfYear)
                {
                    Flights.RemoveAt(i);
                }
            }

            var flights = GenerateFlights();
            foreach (var item in flights)
            {
                Flights.Add(item);
            }
        }

        private List<Flight> GenerateFlights()
        {
            var flights = new List<Flight>();
            
            flights.Add(GenerateFlight());
            flights.Add(GenerateFlight());
            
            return flights;
        }

        public Flight GenerateFlight()
        {
            (City, City) cityPair = CityCatalog.GetRandomCityPair();
            return new Flight
            {
                DepartureCity = cityPair.Item1,
                ArrivalCity = cityPair.Item2,
                RequiredLoad = RoundOff(_random.Next(5000, 50000), 100),
                Forfeit = RoundOff(_random.Next(1000000, 20000000), 1000000),
                PriceFlight = RoundOff(_random.Next(100000, 3000000), 100000),
                ExpireDate = Game.Time.AddDays(_random.Next(1, 7)),
            };
        }

        private static int RoundOff(int i, int interval)
        {
            return ((int)Math.Round(i / (double) interval)) * interval;
        }
    }
}
