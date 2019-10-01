using airport_simulator_2019.Engine;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace airport_simulator_2019.GameObjects
{
    public class FlightBoard : GameObject
    {
        public ObservableCollection<Flight> Flights { get; private set; }

        public FlightBoard()
        {
            Flights = new ObservableCollection<Flight>(GenerateFlights());
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
                PriceFlight = 100000,
                ExpireDate = Game.Time.AddDays(2),
            };
        }
    }
}
