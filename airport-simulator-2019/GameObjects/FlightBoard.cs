using airport_simulator_2019.Engine;
using System.Collections.Generic;

namespace airport_simulator_2019.GameObjects
{
    public class FlightBoard : GameObject
    {
        public List<Flight> Flights { get; private set; }

        public FlightBoard()
        {
            Flights = GenerateFlights();
        }

        public Flight TakeFlight(Flight flight)
        {
            Flights.Remove(flight);
            return flight;
        }

        public override void OnDayBegin()
        {
            Flights.RemoveAll(x => Game.Time.DayOfYear >= x.ExpireDate.DayOfYear);
            Flights.AddRange(GenerateFlights());
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
