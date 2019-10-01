using airport_simulator_2019.Engine;
using System;
using System.Collections.Generic;

namespace airport_simulator_2019.GameObjects
{
    public class Schedule : GameObject
    {
        public Schedule()
        {
            Flights = new List<Flight>();
        }

        public List<Flight> Flights { get; private set; }

        public void Add(Flight flight, Airplane airplane, DateTime time)
        {
            flight.Airplane = airplane;
            flight.DepartureTime = time;
            flight.ArrivalTime = time.AddHours(flight.Distance / airplane.Speed);

            Flights.Add(flight);
        }

        public void CompleteFlight(Airplane airplane)
        {
            Flight flight = Flights.Find(x => x.Airplane == airplane);
            Game.Player.Pay(flight.PriceFlight);
            Flights.Remove(flight);
        }

        public override void OnSecond()
        {
            foreach (Flight flight in Flights)
            {
                if (!flight.InFly)
                {
                    if (flight.Airplane.Location == flight.DepartureCity)
                    {
                        if (flight.DepartureTime.EqualsUpToMinutes(Game.Time))
                        {
                            flight.Airplane.FlyTo(flight.ArrivalCity);
                        }
                    }
                    else
                    {
                        Flights.Remove(flight);
                    }
                }
            }
        }
    }
}
