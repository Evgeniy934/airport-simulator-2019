using airport_simulator_2019.Engine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace airport_simulator_2019.GameObjects
{
    public class Schedule : GameObject
    {
        public ObservableCollection<Flight> Flights { get; private set; }

        public Schedule()
        {
            Flights = new ObservableCollection<Flight>();
        }

        public void Add(Flight flight, Airplane airplane, DateTime time)
        {
            flight.Airplane = airplane;
            flight.DepartureTime = time;
            flight.ArrivalTime = time.AddHours(flight.Distance / airplane.Speed);

            Flights.Add(flight);
        }

        public void CompleteFlight(Flight flight)
        {
            Flights.Remove(flight);
        }

        public override void OnSecond()
        {
            for (int i = Flights.Count - 1; i >= 0; i--)
            {
                Flight flight = Flights[i];
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
